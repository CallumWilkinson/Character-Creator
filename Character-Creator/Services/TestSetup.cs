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
    }
}
