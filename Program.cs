// See https://aka.ms/new-console-template for more information
using System.Data;
using DuckDB.NET.Data;


string actualDirectory = Directory.GetCurrentDirectory();
string fileName = "db-64788265712e570248f32088.db";
string fullPath = Path.Combine(actualDirectory, fileName);

var cns = $"Data Source={fullPath};ACCESS_MODE=read_only";
var conn = new DuckDBConnection(cns);
conn.Open();
var sql = "SELECT COUNT(*) FROM 'tbl-64788265712e570248f32088';";

Parallel.For(0 , 500, i => 
{
    IDbCommand command = conn.CreateCommand();
    command.CommandText = sql;
    var data = command.ExecuteScalar();
    Console.WriteLine($"Result from {i} iterantion is {data}");
});
conn.Close();
