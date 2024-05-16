using System.Data;
using Dapper;

namespace Character_Creator.Services
{
    public class TestSetup
    {

        public void createTable (IDbConnection connection)
        {
            //create table for testing
            connection.Execute(@"
            CREATE TABLE IF NOT EXISTS Characters (
                CharacterID INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Race TEXT NOT NULL,
                Class TEXT NOT NULL,
                Level INTEGER NOT NULL
            );");
        }

        public void addInitialCharacters(IDbConnection connection)
        {
            //add 5 characters to db
            var insertDataQuery = @"
                INSERT INTO Characters (Name, Race, Class, Level) VALUES ('Chadowform', 'Night Elf', 'Druid', 15);
                INSERT INTO Characters (Name, Race, Class, Level) VALUES ('Trapsbrah', 'Human', 'Warrior', 60);
                INSERT INTO Characters (Name, Race, Class, Level) VALUES ('Nabz', 'Gnome', 'Mage', 3);
                INSERT INTO Characters (Name, Race, Class, Level) VALUES ('Orcboi', 'Orc', 'Warlock', 26);
                INSERT INTO Characters (Name, Race, Class, Level) VALUES ('Nuffiet', 'Dwarf', 'Paladin', 38);
            ";
            connection.Execute(insertDataQuery);
        }
    }
}
