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
            //this is polymorphism - the SqliteConnection class implements the IDbConnection interface.
            //so i can switch out the SqliteConnection class for a different connection type like SqlConnection for Microsoft SQL Server.
            //this way i can use any database I want and keep the code that uses the IDbConnection interface.
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