using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;
using Character_Creator.Models;

namespace Character_Creator.Services;

public class DataService
{
    private readonly IDbConnection _db;

    public DataService(IDbConnection db)
    {
       _db = db;
    }

    public int AddCharacter(Character character)
    {
        
        {
            _db.Open();
            var sql = "INSERT INTO Characters (Name, Race, Class, Level) VALUES (@Name, @Race, @Class, @Level)";
            int rowsaffected = _db.Execute(sql, character);
            return rowsaffected;
        }

  
    }
}
