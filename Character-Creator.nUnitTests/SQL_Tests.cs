using NUnit.Framework;
using Microsoft.Data.Sqlite;
using Dapper;
using System.Data;
using Character_Creator.Services;
using Character_Creator.Models;
using Microsoft.Extensions.Configuration;
using NUnit.Framework.Legacy;


namespace Character_Creator.nUnitTests
{
    [TestFixture]
    public class DataServiceTests
    {
        private IDbConnection _connection;

        [SetUp]
        public void Setup()
        {
            //setup in memory database connection
            _connection = new SqliteConnection("Data Source=:memory:");
            _connection.Open();

            //create table for testing
            _connection.Execute(@"
            CREATE TABLE IF NOT EXISTS Characters (
                CharacterID INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Race TEXT NOT NULL,
                Class TEXT NOT NULL,
                Level INTEGER NOT NULL
            );");

            //expecting dapper to return 0 as it will only return 1 when a row is affected
            //and since this is creating a table, technically no rows are affected so its normal for it to be zero
            //therefore it appears that the table is created successfully so the issue is not here
            
        }

        [TearDown]
        public void Teardown() 
        {
            //close in-memory database
            _connection.Close();
        }

        [Test]
        public void AddCharacterToDatabase()
        {
            //Arrange


            var dataservice = new DataService(_connection);
            var character = new Character
            {
                Name = "Nibzy",
                Race = "Night Elf",
                Class = "Hunter",
                Level = 10,
            };

            //Act
            int result = dataservice.AddCharacter(character);

            //Assert
            ClassicAssert.AreEqual(result, 1);
        }
    }
}