using CsvHelper;
using CsvHelper.Configuration;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using PolRouteDSOracleImporter;
using PolRouteDSOracleImporter.Models;
using System.Globalization;

Console.WriteLine("PolRouteDS Oracle Importer Start!");

var csvDir = "C:\\GIT\\oracle-partitions\\csv\\";
string connString = "DATA SOURCE=localhost:1521/xe; PERSIST SECURITY INFO=True;USER ID=MYUSER; password=PASSPASS; Pooling = False;";

var config = new CsvConfiguration(CultureInfo.InvariantCulture)
{
    PrepareHeaderForMatch = args => args.Header.ToSnakeCase(),
    Delimiter = ";"
};

var tables = new List<ITable>();
tables.Add(new Table<District>());
tables.Add(new Table<Neighborhood>());
tables.Add(new Table<Time>());
tables.Add(new Table<Vertice>());
tables.Add(new Table<Segment>());
tables.Add(new Table<Crime>());

try
{
    foreach (var table in tables)
    {
        using (var reader = new StreamReader(csvDir + table.Filename))
        using (var csv = new CsvReader(reader, config))
        {
            Console.WriteLine("Loading CSV " + table.Name);
            var records = csv.GetRecords(table.Type).ToList();
            var total = records.Count();
            int i = 1;
            using (var connection = new OracleConnection(connString))
            {
                connection.Open();
                Console.WriteLine("Writing " + table.Name + " Start!");

                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "TRUNCATE TABLE " + table.TableName;
                    command.ExecuteNonQuery();
                }

                foreach (var record in records)
                {
                    var obj = (IQueryGenerator)record;

                    try
                    {
                        using (OracleCommand command = new OracleCommand())
                        {
                            Console.WriteLine("Writing " + table.Name + " | " + i + "/" + total);
                            command.Connection = connection;
                            command.CommandText = obj.GenerateInsertQuery(command);
                            command.ExecuteNonQuery();
                            i++;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}