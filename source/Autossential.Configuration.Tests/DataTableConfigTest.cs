using Autossential.Configuration.Core.Resolvers;
using Autossential.Configuration.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

namespace Autossential.Configuration.Tests
{
    [TestClass]
    public class DataTableConfigTest
    {
        private static readonly DataTable _dataTable = new DataTable();

        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            _dataTable.Columns.Add("First", typeof(string));
            _dataTable.Columns.Add("Second", typeof(object));

            _dataTable.Rows.Add(new object[] { "A", "ValueA" });
            _dataTable.Rows.Add(new object[] { "B", "ValueB" });
            _dataTable.Rows.Add(new object[] { "C", 10 });
            _dataTable.Rows.Add(new object[] { "D", true });
            _dataTable.Rows.Add(new object[] { "E", new DateTime(1983, 7, 30) });
        }

        [TestMethod]
        public void Keys()
        {
            var config = new ConfigSection(new DataTableSectionResolver(_dataTable, "First", "Second"));
            var keys = new string[] { "A", "B", "C", "D", "E" };
            foreach (var key in keys)
                Assert.IsTrue(config.HasKey(key), key + " not found");
        }

        [TestMethod]
        public void Values()
        {
            var config = new ConfigSection(new DataTableSectionResolver(_dataTable, "First", "Second"));

            Assert.AreEqual("ValueA", config.AsString("A"));
            Assert.AreEqual("ValueB", config.AsString("B"));
            Assert.AreEqual(10, config.AsInt("C"));
            Assert.IsTrue(config.AsBoolean("D"));
            Assert.AreEqual(new DateTime(1983, 7, 30), config.AsDateTime("E"));
        }
    }
}
