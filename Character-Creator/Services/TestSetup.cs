using System.Data;
using Character_Creator.Models;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Character_Creator.Services
{
    public class TestSetup
    {
        public void Run(IDbConnection connection)
        {
            //check if table already exists
            var sql = "SELECT name FROM sqlite_master WHERE type='table' AND name='Characters'";
            var tableCheckQuery = new SqliteCommand(sql, (SqliteConnection?)connection);
            var tableName = tableCheckQuery.ExecuteScalar();

            if (tableName == null)
            {
                //create table for testing if it does not exist already
                connection.Execute(@"
                    CREATE TABLE Characters (
                        CharacterID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Race TEXT NOT NULL,
                        Class TEXT NOT NULL,
                        Level INTEGER NOT NULL
                    );");

                //create 5 character objects
                Character Chadowform = new Character
                {
                    Name = "Chadowform",
                    Race = "Night Elf",
                    Class = "Druid",
                    Level = 15,
                };
                Character Trapsbrah = new Character
                {
                    Name = "Trapsbrah",
                    Race = "Human",
                    Class = "Warrior",
                    Level = 60,
                };
                Character Nabz = new Character
                {
                    Name = "Nabz",
                    Race = "Gnome",
                    Class = "Mage",
                    Level = 3,
                };
                Character Orcboi = new Character
                {
                    Name = "Orcboi",
                    Race = "Orc",
                    Class = "Warlock",
                    Level = 26,
                };
                Character Nuffiet = new Character
                {
                    Name = "Nuffiet",
                    Race = "Dwarf",
                    Class = "Paladin",
                    Level = 38,
                };

                //create Dataservice object
                DataService dataService = new DataService(connection);


                //add characters to db
                dataService.AddCharacter(Chadowform);
                dataService.AddCharacter(Trapsbrah);
                dataService.AddCharacter(Nabz);
                dataService.AddCharacter(Orcboi);
                dataService.AddCharacter(Nuffiet);
            }
        }
    }
}
