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
        using (IDbConnection db = new SqliteConnection(_connectionString))
            //this is the issue! var db is set to sqlite db, state is closed so no table exists
            //var db should be pointing to my inmemory db
            //i need to figure out why the state of the db is closed
            //i think its cos the databse is closed, it runs the insert then opens, so the table is created then erased when closed
            //its asif this line above creats a second in memory db, it doesnt use the one that is created when the test starts and the table is added??
            //probaby cos of the new keyword

            //so how do i, in the line above, reference the in memory db made in the test??

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
