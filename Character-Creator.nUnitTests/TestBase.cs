using Character_Creator.Services;
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

    public abstract class TestBase
    {
        protected IDbConnection _connection;

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


    }
}
