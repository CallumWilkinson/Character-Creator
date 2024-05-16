using NUnit.Framework;
using Microsoft.Data.Sqlite;
using Dapper;
using System.Data;
using Character_Creator.Services;
using Character_Creator.Models;
using Microsoft.Extensions.Configuration;
using NUnit.Framework.Legacy;
using FluentAssertions;


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

            var testsetup = new TestSetup();
            testsetup.createTable(_connection);
            testsetup.addInitialCharacters(_connection);
        }

        [TearDown]
        public void Teardown() 
        {
            //close in-memory database
            _connection.Close();
        }

        [Test]
        public void TestAddCharacterToDatabase()
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
            var expectedCharacter = dataservice.GetCharacterByID(result);

            //Assert
            expectedCharacter.Name.Should().Be("Nibzy");

        }
    }
}