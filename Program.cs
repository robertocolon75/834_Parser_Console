//// See https://aka.ms/new-console-template for more information
//using AptusEdiParser;
//using AutoMapper;
//using System.Data;
//using System.Data.SqlClient;
//using TestConsole;
//using TestConsole.Models;
//using TestConsole.Validators;

//var path = @"d:\files\834\SUS\";
//var filePath = path + @"20231120_PSM_690900_834DI_01.X12";
//var _834 = new File834(filePath);

////TestConsole.SqlTableGenerator.GenerateTableScript();
////return;
//using (IDbConnection conn = new SqlConnection(@"Server=.;Initial Catalog=834;Trusted_Connection=true"))
//{
//    Global.File834Id = conn.Insert(_834);
//    _834.File834Id = Global.File834Id;
//}

//var F = new FileParser(filePath);
//var file = F.ParseMe();
////JsonDumper.DumpObjectToJsonFile(file, path + "Filetest.json");
////return;
//var config = new MapperConfiguration(cfg => cfg.AddMaps("TestConsole"));
//var mapper = new Mapper(config);
//InterchangeControlHeader dto = mapper.Map<InterchangeControlHeader>(file);
//Global.IsValidFile<InterchangeControlHeaderValidator, InterchangeControlHeader>(dto);
////JsonDumper.DumpObjectToJsonFile(dto, path + "Maptest.json");
//var DbInserter = new DatabaseInserter(dto);
//DbInserter.Insert();

//using (IDbConnection conn = new SqlConnection(@"Server=.;Initial Catalog=834;Trusted_Connection=true"))
//{
//    _834.LastUpdateDate = DateTime.Now;
//    conn.Update(_834);
//}

// See https://aka.ms/new-console-template for more information
using _834FilePareserControl;
using System.Text.RegularExpressions;

namespace DriverAssigner
{
    internal class Program
    {
        internal const string EnvironmentVariable = "";

        private static string env => Environment.GetEnvironmentVariable(EnvironmentVariable) ?? "Production";

        internal static async Task Main(string[] args)
        {
            string path = null;
            string connectionString = null;
            string fileType = null;

            string commandLine = string.Join(" ", args);
            string pattern = @"-p\s+'([^']*)'\s+-cs\s+'([^']*)'\s+-f\s+(\d)";

            Match match = Regex.Match(commandLine, pattern);

            if (match.Success)
            {
                path = match.Groups[1].Value;
                connectionString = match.Groups[2].Value;
                fileType = match.Groups[3].Value;

                Console.WriteLine($"Path: {path}");
                Console.WriteLine($"Connection String: {connectionString}");
                var app = new ProcessFile();
                app.Run(path, connectionString, fileType);
            }
            else
            {
                Console.WriteLine("Invalid command-line arguments.");
                return;
            }

            // Now you can use the options

            //var app= ConsoleApp.Create(args);
            //app.AddCommands<ProcessFile>();
            //await app.RunAsync();
        }
    }
}