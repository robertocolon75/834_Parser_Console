using _834FilePareserControl.Models;
using _834FilePareserControl.Validators;
using AptusEdiParser;
using AutoMapper;
using Dapper;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace _834FilePareserControl
{
    public class ProcessFile // : ConsoleAppBase
    {
        private IOptions<MyConfig> settings;

        public ProcessFile()
        {
        }

        //public ProcessFile(Settings settings) => (this.settings) = (settings);
        private string Conn { get; set; }

        private string FileType { get; set; }

        //[RootCommand]
        //public  Task Run([Option("p", "Path for 834 files")] string directoryPath,[Option("cs", "ConnectionString")] string conn)
        public Task Run(string directoryPath, string conn, string fileType)
        {
            // var directoryPath = @"d:\files\834\SUS\";

            //filePath = directoryPath + @"648127_834DO_690900_20231115_01.X12";
            //ParseMe(filePath, false);
            //return;

            //Console.WriteLine("Processing files in " + directoryPath);
            //Console.WriteLine("Conn: " + conn);
            //Console.WriteLine("Press any key to continue...");
            //Console.ReadLine();
            //return Task.CompletedTask;

            Conn = conn;
            FileType = fileType;
            string[] files = Directory.GetFiles(directoryPath, "*.x12");
            bool schemaOnly = false;
            foreach (string file in files)
            {
                Console.WriteLine("Processing " + file);
                ParseMe(file, schemaOnly);
                if (schemaOnly) break;
            }
            return Task.CompletedTask;
            //Console.ReadLine();
        }

        private async Task ParseMe(string filePath, bool onlySchema = false)
        {
            try
            {
                if (onlySchema)
                {
                    SqlTableGenerator.GenerateTableScript();
                    return;
                }
                var _834 = new File834(filePath);
                Console.WriteLine("Inserting File834...");
                using (IDbConnection conn = new SqlConnection(Conn))
                {
                    Global.File834Id = conn.QuerySingle<long>($"Insert into File834 (Filepath,FileType) values ('{filePath}',{FileType}); SELECT SCOPE_IDENTITY();");
                    _834.File834Id = Global.File834Id;
                }
                Console.WriteLine("File834 inserted...");
                var F = new FileParser(filePath);
                Console.WriteLine("Parsing file...");
                var file = F.ParseMe();
                //var test = file.Groups.Headers.Loop2000.Where(i => i.Loop2300s != null).Select(x => x.Loop2300s);

                //foreach (var item in test)
                //{
                //    foreach (var item2 in item)
                //    {
                //        if (item2.Loop2310s != null)
                //        {
                //            Console.WriteLine(item2.Loop2310s);
                //        }
                //        if (item2.Loop2320s != null)
                //        {
                //            Console.WriteLine(item2.Loop2320s);
                //        }
                //    }
                //}
                //JsonDumper.DumpObjectToJsonFile(file, path + "Filetest.json");
                //return;
                Console.WriteLine("Mapping file...");
                var config = new MapperConfiguration(cfg => cfg.AddMaps("834FileParserConsole"));
                var mapper = new Mapper(config);
                InterchangeControlHeader dto = mapper.Map<InterchangeControlHeader>(file);
                Global.IsValidFile<InterchangeControlHeaderValidator, InterchangeControlHeader>(dto, Conn);
                //JsonDumper.DumpObjectToJsonFile(dto, path + "Maptest.json");
                Console.WriteLine("Inserting file...");
                var DbInserter = new DatabaseInserter(dto);
                DbInserter.Insert(Conn);
                Console.WriteLine("File inserted...");
                using (IDbConnection conn2 = new SqlConnection(Conn))
                {
                    var totalSegmentsInserted = conn2.QuerySingle<int>("exec stg.ValidateParsing", commandType: CommandType.Text);
                    var totalSegmentsOnFile = dto.FGH.Headers.TransactionSegmentCount;
                    Console.WriteLine("Updating File834 Table...");
                    conn2.Execute(@"Update dbo.File834 set LastUpdateDate=@lastupdatedate
                                                        ,TotalSegmentsInserted=@totalSegmentsInserted
                                                        ,TotalSegmentsOnFile=@totalSegmentsOnFile
                                                        where File834Id=@File834Id"
                        , new { lastupdatedate = DateTime.Now, Global.File834Id, totalSegmentsInserted, totalSegmentsOnFile });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}