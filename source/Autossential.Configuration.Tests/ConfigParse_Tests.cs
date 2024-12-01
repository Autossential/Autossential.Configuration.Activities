using Autossential.Configuration.Activities;
using Autossential.Configuration.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Activities;
using System.Collections.Generic;

namespace Autossential.Configuration.Tests
{
    [TestClass]
    public class ConfigParse_Tests
    {
        private const string JsonContent = @"
    {
        ""AppSettings"": {
            ""Setting1"": ""Value1"",
            ""Setting2"": 10,
            ""Setting3"": true,
            ""NestedSetting"": {
                ""SubSetting1"": ""SubValue1"",
                ""SubSetting2"": 3.14,
                ""ArraySetting"": [""Item1"", ""Item2"", ""Item3""]
            }
        }
    }";

        private const string YamlContent = @"
    AppSettings:
      Setting1: ""Value1""
      Setting2: 10
      Setting3: true
      NestedSetting:
        SubSetting1: ""SubValue1""
        SubSetting2: 3.14
        ArraySetting:
          - ""Item1""
          - ""Item2""
          - ""Item3""
    ";

        [TestMethod]
        public void Execute_ValidJsonContent_ReturnsConfigSection()
        {
            var configParse = new ConfigParse
            {
                Content = new InArgument<string>(JsonContent)
            };

            var result = WorkflowInvoker.Invoke(configParse);

            Assert.IsNotNull(result);
            Assert.AreEqual("Value1", result.AsString("AppSettings/Setting1"));
            Assert.AreEqual(10, result.AsInt("AppSettings/Setting2"));
            Assert.IsTrue(result.AsBoolean("AppSettings/Setting3"));
            Assert.AreEqual("SubValue1", result.AsString("AppSettings/NestedSetting/SubSetting1"));
            Assert.AreEqual(3.14, result.AsDouble("AppSettings/NestedSetting/SubSetting2"));
            CollectionAssert.AreEqual(new List<string> { "Item1", "Item2", "Item3" }, result.AsList<string>("AppSettings/NestedSetting/ArraySetting"));
        }

        [TestMethod]
        public void Execute_ValidYamlContent_ReturnsConfigSection()
        {
            var configParse = new ConfigParse
            {
                Content = new InArgument<string>(YamlContent)
            };

            var result = WorkflowInvoker.Invoke(configParse);

            Assert.IsNotNull(result);
            Assert.AreEqual("Value1", result.AsString("AppSettings/Setting1"));
            Assert.AreEqual(10, result.AsInt("AppSettings/Setting2"));
            Assert.IsTrue(result.AsBoolean("AppSettings/Setting3"));
            Assert.AreEqual("SubValue1", result.AsString("AppSettings/NestedSetting/SubSetting1"));
            Assert.AreEqual(3.14, result.AsDouble("AppSettings/NestedSetting/SubSetting2"));
            CollectionAssert.AreEqual(new List<string> { "Item1", "Item2", "Item3" }, result.AsList<string>("AppSettings/NestedSetting/ArraySetting"));
        }

        [TestMethod]
        public void Execute_NullContent_ReturnsEmptyConfigSection()
        {
            var configParse = new ConfigParse
            {
                Content = null
            };

            var result = WorkflowInvoker.Invoke(configParse);
            Assert.AreEqual(result.Count, 0);
        }
    }

}
