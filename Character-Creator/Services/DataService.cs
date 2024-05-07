using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;
using Character_Creator.Models;

namespace Character_Creator.Services;

public class DataService
{
    private readonly string _connectionString;

    public DataService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        if (_connectionString == null )
        {
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }
    }

    public int AddCharacter(Character character)
    {
        using (var db = new SqliteConnection(_connectionString))
            //this is the issue, var db is set to sqlite db, state is closed so no table exists
        {
            var sql = "INSERT INTO Characters (Name, Race, Class, Level) VALUES (@Name, @Race, @Class, @Level)";
            return db.Execute(sql, character);
        }

        //i think the issue is that i made the table using the DB gui when i first started the project
        //try making the table with code?
       //maybe the above function isnt using the inmemory database i made in my test?
       //the issue has to be here - for some reason it thinks there is no table called characters
    }
}
