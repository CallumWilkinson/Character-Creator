using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;
using Character_Creator.Models;

namespace Character_Creator.Services;

public class DataService
{
    //Using an IDbConnection interface type to ensure in-memory database created in test continues to stay open.
    //Each new instance of SqliteConnection class creates a seperate in-memory database, even if you use the same connection string.
    //This ensures i can create an in-memory database in my test and keep that connection open in this class.
    private readonly IDbConnection _db;

    //do i need dbSet field?


    //this is dependency injection as the class doesnt depend on a specific database
    //I can instantiate the class with an in memory db or a persistant one
    //this is very testable code
    public DataService(IDbConnection db)
    {
       _db = db;
    }

    public int AddCharacter(Character character)
    {
        
        {
            //dont think i need _db.Open(); but it reads better with it here
            _db.Open();
            var sql = "INSERT INTO Characters (Name, Race, Class, Level) VALUES (@Name, @Race, @Class, @Level)";
            int rowsaffected = _db.Execute(sql, character);
            return rowsaffected;

            //in my projects database, i want to delete the table made in the gui and create an sql query to make the table, i think?
        }

  
    }
}
