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

            //act
            testsetup.Run(_connection);
            Character Chadowform = dataService.GetCharacterByID(1);
            Character Trapsbrah = dataService.GetCharacterByID(2);
            Character Nabz = dataService.GetCharacterByID(3);
            Character Orcboi = dataService.GetCharacterByID(4);
            Character Nuffiet = dataService.GetCharacterByID(5);

            //assert
            Chadowform.Name.Should().Be("Chadowform");
            Trapsbrah.Name.Should().Be("Trapsbrah");
            Nabz.Name.Should().Be("Nabz");
            Orcboi.Name.Should().Be("Orcboi");
            Nuffiet.Name.Should().Be("Nuffiet");

        }
    }
}
