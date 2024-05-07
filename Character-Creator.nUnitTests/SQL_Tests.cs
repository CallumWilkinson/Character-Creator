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
        private SqliteConnection _connection;

        [SetUp]
        public void Setup()
        {
            //setup in memory database connection
            _connection = new SqliteConnection("Data Source=:memory:");
            _connection.Open();

            //create table for testing
            _connection.Execute(@"
            CREATE TABLE Characters (
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

            //setup configuration with connection string
           var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["ConnectionStrings:DefaultConnection"] = _connection.ConnectionString,
                })
                .Build();



            var dataservice = new DataService(configuration);
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