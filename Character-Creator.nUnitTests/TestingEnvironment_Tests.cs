using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.Data.Sqlite;
using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using NUnit.Framework.Legacy;
using FluentAssertions;
using Character_Creator.Services;
using Character_Creator.Models;

namespace Character_Creator.nUnitTests
{
    [TestFixture]
    public class TestingEnvironment_Tests
    {
        private IDbConnection _connection;

        [SetUp]
        public void Setup()
        {
            _connection = new SqliteConnection("Data Source=:memory:");
            _connection.Open();
        }

        [TearDown]
        public void Teardown()
        {
            //close in-memory database
            _connection.Close();
        }

        [Test]
        public void TestingTheTestSetupClass() 
        {
            //arrange
            TestSetup testsetup = new TestSetup();
            DataService dataService = new DataService(_connection);
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


            //act
            testsetup.createTable(_connection);
            dataService.AddCharacter(Chadowform);
            dataService.AddCharacter(Trapsbrah);
            dataService.AddCharacter(Nabz);
            dataService.AddCharacter(Orcboi);
            dataService.AddCharacter(Nuffiet);
           

            //assert
        }
    }
}
