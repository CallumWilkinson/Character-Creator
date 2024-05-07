using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;

namespace Character_Creator.Services;

public class DataService
{
    private readonly string _connectionString;

    public DataService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
}
