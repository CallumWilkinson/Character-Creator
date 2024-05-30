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



    //this is dependency injection as the class doesnt depend on a specific database
    //I can instantiate the class with an in memory db or a persistant one
    //this is very testable code
    public DataService(IDbConnection db)
    {
       _db = db;
    }

 

    public int AddCharacter(Character character)
    {
        //dont think i need _db.Open(); but it reads better with it here
        _db.Open();
        var sql = "INSERT INTO Characters (Name, Race, Class, Level) " +
            "VALUES (@Name, @Race, @Class, @Level);" +
            "SELECT last_insert_rowid();";

        //executeScalar will return the first record of the row that was jsut inserted becuase i added "SELECT last_insert_rowid();, which will be the ID
        //whereas regular .execute will only return the amount of rows added
        int characterID = _db.ExecuteScalar<int>(sql, character);
        return characterID;
        
    }

    public Character GetCharacterByID(int id)
    {
        var sql = "SELECT * FROM Characters WHERE CharacterId = @Id";
        //parameters object is used to pass the id value into the query, it creates a temporary object that holds the ID propery so that Dapper can map the @ID placeholder in the sql query
        var parameters = new {Id = id};
        var character = _db.QueryFirstOrDefault<Character>(sql, parameters);

        return character;
    }

    public List<Character> GetAllCharacters()
    {
        var sql = "SELECT * FROM Characters";
        var listOfCharacters = _db.Query<Character>(sql).ToList();
        var orderedListOfCharacters = listOfCharacters.OrderByDescending(c => c.CharacterId).ToList();
        return orderedListOfCharacters;
    }

    public void DeleteCharacter(int id) 
    {
        var sql = "DELETE FROM Characters WHERE CharacterId = @Id";
        var parameters = new {Id = id};
        var delete = _db.QueryFirstOrDefault<Character>(sql,parameters);
    }


    public Character EditCharacter(Character character)
    {
        return character;
    }
   

 
}
