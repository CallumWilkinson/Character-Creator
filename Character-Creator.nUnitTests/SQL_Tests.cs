using NUnit.Framework;
using Microsoft.Data.Sqlite;
using Dapper;
using System.Data;
using Character_Creator.Services;
using Character_Creator.Models;
using Microsoft.Extensions.Configuration;
using NUnit.Framework.Legacy;
using FluentAssertions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


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

            //add 5 characters to db, note that these are not character objects
            var insertDataQuery = @"
                INSERT INTO Characters (Name, Race, Class, Level) VALUES ('Chadowform', 'Night Elf', 'Druid', 15);
                INSERT INTO Characters (Name, Race, Class, Level) VALUES ('Trapsbrah', 'Human', 'Warrior', 60);
                INSERT INTO Characters (Name, Race, Class, Level) VALUES ('Nabz', 'Gnome', 'Mage', 3);
                INSERT INTO Characters (Name, Race, Class, Level) VALUES ('Orcboi', 'Orc', 'Warlock', 26);
                INSERT INTO Characters (Name, Race, Class, Level) VALUES ('Nuffiet', 'Dwarf', 'Paladin', 38);
            ";
            _connection.Execute(insertDataQuery);

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
            DataService dataservice = new DataService(_connection);
            Character character = new Character
            {
                Name = "Nibzy",
                Race = "Night Elf",
                Class = "Hunter",
                Level = 10,
            };

            //Act
            int characterID = dataservice.AddCharacter(character);
            Character expectedCharacter = dataservice.GetCharacterByID(characterID);

            //Assert
            expectedCharacter.Name.Should().Be("Nibzy");

        }
    }
}