using Autossential.Configuration.Activities;
using Autossential.Configuration.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Activities;
using System.Data;

namespace Autossential.Configuration.Tests
{
    [TestClass]
    public class DataTableToConfig_Tests
    {
        [TestMethod]
        public void Execute_ValidDataTable_ReturnsConfigSection()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Key", typeof(string));
            dataTable.Columns.Add("Value", typeof(object));

            dataTable.Rows.Add("Name", "John Doe");
            dataTable.Rows.Add("Email", "johndoe@example.com");
            dataTable.Rows.Add("BirthDate", new DateTime(1980, 1, 1));
            dataTable.Rows.Add("Street", "123 Elm St");
            dataTable.Rows.Add("City", "Springfield");
            dataTable.Rows.Add("ZipCode", "12345");

            var dataTableToConfig = new DataTableToConfig
            {
                DataTable = new InArgument<DataTable>(_ => dataTable),
                KeyColumnName = new InArgument<string>("Key"),
                ValueColumnName = new InArgument<string>("Value")
            };

            var result = WorkflowInvoker.Invoke(dataTableToConfig);

            Assert.IsNotNull(result);
            Assert.AreEqual("John Doe", result.AsString("Name"));
            Assert.AreEqual("johndoe@example.com", result.AsString("Email"));
            Assert.AreEqual(new DateTime(1980, 1, 1), result.AsDateTime("BirthDate"));
            Assert.AreEqual("123 Elm St", result.AsString("Street"));
            Assert.AreEqual("Springfield", result.AsString("City"));
            Assert.AreEqual("12345", result.AsString("ZipCode"));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Execute_NullDataTable_ThrowsArgumentNullException()
        {
            var dataTableToConfig = new DataTableToConfig
            {
                DataTable = null,
                KeyColumnName = new InArgument<string>("Key"),
                ValueColumnName = new InArgument<string>("Value")
            };

            WorkflowInvoker.Invoke(dataTableToConfig);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Execute_EmptyKeyColumnName_ThrowsArgumentException()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Key", typeof(string));
            dataTable.Columns.Add("Value", typeof(object));

            var dataTableToConfig = new DataTableToConfig
            {
                DataTable = new InArgument<DataTable>(_ => dataTable),
                KeyColumnName = new InArgument<string>(string.Empty),
                ValueColumnName = new InArgument<string>("Value")
            };

            WorkflowInvoker.Invoke(dataTableToConfig);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Execute_EmptyValueColumnName_ThrowsArgumentException()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Key", typeof(string));
            dataTable.Columns.Add("Value", typeof(object));

            var dataTableToConfig = new DataTableToConfig
            {
                DataTable = new InArgument<DataTable>(_ => dataTable),
                KeyColumnName = new InArgument<string>("Key"),
                ValueColumnName = new InArgument<string>(string.Empty)
            };

            WorkflowInvoker.Invoke(dataTableToConfig);
        }

        [TestMethod]
        public void Execute_EmptyDataTable_ReturnsEmptyConfigSection()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Key", typeof(string));
            dataTable.Columns.Add("Value", typeof(object));

            var dataTableToConfig = new DataTableToConfig
            {
                DataTable = new InArgument<DataTable>(_ => dataTable),
                KeyColumnName = new InArgument<string>("Key"),
                ValueColumnName = new InArgument<string>("Value")
            };

            var result = WorkflowInvoker.Invoke(dataTableToConfig);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }
    }
}