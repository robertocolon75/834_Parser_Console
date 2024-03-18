using AptusEdiParser.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;
using TextCopy;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;

namespace _834FilePareserControl
{
    public static class SqlTableGenerator
    {
        private static Dictionary<string, Type> typeMappings = new Dictionary<string, Type>
        {
        };

        public static string GenerateTableScript()
        {
            var sb = new StringBuilder();

            var types = AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(a => a.GetTypes())
                       .Where(t => t.GetCustomAttributes(typeof(IncludeInTypeMappingAttribute), false).Length > 0);

            foreach (var type in types)
            {
                var tableName = type.GetCustomAttribute<Dapper.Contrib.Extensions.TableAttribute>()?.Name ?? type.Name;
                var tableNameSplit = tableName.Split('.');
                sb.AppendLine($"Drop TABLE IF EXISTS {tableName} ; ");
                sb.AppendLine($"CREATE TABLE {tableName} (");

                var propertyScripts = new List<string>();
                foreach (var property in type.GetProperties())
                {
                    if (property.GetCustomAttribute<WriteAttribute>() != null)
                    {
                        continue; // Skip properties that are not mapped to a database column
                    }

                    var columnName = property.GetCustomAttribute<ColumnAttribute>()?.Name ?? property.Name;
                    var columnType = GetColumnType(property.PropertyType);
                    var isPrimaryKey = property.GetCustomAttribute<KeyAttribute>() != null;
                    var isIdentity = property.GetCustomAttribute<DatabaseGeneratedAttribute>()?.DatabaseGeneratedOption == DatabaseGeneratedOption.Identity;
                    var ignoreMe = property.GetCustomAttribute<NotMappedAttribute>() != null;
                    var script = $"    [{columnName}] {columnType}";

                    if (ignoreMe) goto Proximo;
                    if (isPrimaryKey)
                    {
                        script += " PRIMARY KEY  IDENTITY(1,1)";
                    }
                    //if (isIdentity)
                    //{
                    //    script += " IDENTITY(1,1)";
                    //}
                    if (Nullable.GetUnderlyingType(property.PropertyType) == null && property.PropertyType.IsValueType && !isPrimaryKey)
                    {
                        script += " NOT NULL";
                    }

                    propertyScripts.Add(script);
                Proximo:;
                }
                propertyScripts.Add($"    LastUpdateDate datetime2 CONSTRAINT [df_{tableNameSplit[1]}_LastUpdateDate] DEFAULT sysdatetime()");
                propertyScripts.Add($"    LastUpdateId varchar(64) CONSTRAINT [df_{tableNameSplit[1]}_LastUpdateId] DEFAULT suser_name()");
                // propertyScripts.Add($" FileNameId int not null");
                sb.Append(string.Join(",\n", propertyScripts));
                sb.AppendLine("\n);");
            }
            ClipboardService.SetText(sb.ToString());

            return sb.ToString();
        }

        private static string GetColumnType(Type type)
        {
            // Handle nullable types
            var underlyingType = Nullable.GetUnderlyingType(type) ?? type;

            if (underlyingType.IsEnum)
            {
                return "INT"; // Or however you like to store Enums
            }

            var map = new Dictionary<Type, string>
            {
                [typeof(int)] = "INT",
                [typeof(long)] = "BIGINT",
                [typeof(short)] = "SMALLINT",
                [typeof(byte)] = "TINYINT",
                [typeof(bool)] = "BIT",
                [typeof(DateTime)] = "DATETIME",
                [typeof(float)] = "REAL",
                [typeof(double)] = "FLOAT",
                [typeof(decimal)] = "DECIMAL(18, 2)",
                [typeof(Guid)] = "UNIQUEIDENTIFIER",
                // add mappings for other types as necessary
            };

            if (map.TryGetValue(underlyingType, out var sqlType))
            {
                return sqlType;
            }

            if (underlyingType == typeof(string))
            {
                return $"VARCHAR(255)"; // You might want to have a way to specify the length
            }

            throw new ArgumentException($"Unrecognized type: {type.Name}");
        }
    }
}