using Character_Creator.Models;
using Character_Creator.Services;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character_Creator.nUnitTests
{

    [TestFixture]

    public class UpdateCharacterTest
    {
        private IDbConnection _connection;

        [SetUp]
        public void Setup()
        {
            _connection = new SqliteConnection("Data Source=:memory:");
            _connection.Open();

            TestSetup testSetup = new TestSetup();
            testSetup.Run(_connection);
        }

        [TearDown]
        public void Teardown()
        {
            //close in-memory database
            _connection.Close();
        }

        [Test]

        public void TestingUpdateFunction()
        {
            //Arrange
            DataService database = new DataService(_connection);
            Character updatedCharacter = new Character
            {
                CharacterId = 1,
                Name = "Charlieboi",
                Race = "Cat",
                Class = "Hunter",
                Level = 60,
            };

            //Act
            var rowsaffected = database.UpdateCharacter(updatedCharacter);
            var newCharacterInDatabase = database.GetCharacterByID(1);


            //Assert
            rowsaffected.Should().Be(1);
            newCharacterInDatabase.Name.Should().Be("Charlieboi");

        }
    }
}
