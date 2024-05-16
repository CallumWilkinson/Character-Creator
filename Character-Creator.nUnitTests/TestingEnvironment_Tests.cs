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
            TestSetup testsetup = new TestSetup();
            testsetup.createTable(_connection);
            testsetup.addInitialCharacters(_connection);
        }
    }
}
