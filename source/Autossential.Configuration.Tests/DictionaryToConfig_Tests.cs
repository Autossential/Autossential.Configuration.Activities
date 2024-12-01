using Autossential.Configuration.Activities;
using Autossential.Configuration.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Activities;
using System.Collections.Generic;

namespace Autossential.Configuration.Tests
{
    [TestClass]
    public class DictionaryToConfig_Tests
    {
        [TestMethod]
        public void Execute_ValidDictionary_ReturnsConfigSection()
        {
            var dictionary = new Dictionary<string, object>
            {
                { "Setting1", "Value1" },
                { "Setting2", 10 },
                { "Setting3", true },
                { "NestedSetting", new Dictionary<string, object>
                    {
                        { "SubSetting1", "SubValue1" },
                        { "SubSetting2", 3.14 },
                        { "ArraySetting", new List<object> { "Item1", "Item2", "Item3" } }
                    }
                }
            };

            var dictionaryToConfig = new DictionaryToConfig
            {
                Dictionary = new InArgument<Dictionary<string, object>>(_ => dictionary)
            };

            var result = WorkflowInvoker.Invoke(dictionaryToConfig);

            Assert.IsNotNull(result);
            Assert.AreEqual("Value1", result.AsString("Setting1"));
            Assert.AreEqual(10, result.AsInt("Setting2"));
            Assert.IsTrue(result.AsBoolean("Setting3"));
            Assert.AreEqual("SubValue1", result.AsString("NestedSetting/SubSetting1"));
            Assert.AreEqual(3.14, result.AsDouble("NestedSetting/SubSetting2"));
            CollectionAssert.AreEqual(new List<string> { "Item1", "Item2", "Item3" }, result.AsList<string>("NestedSetting/ArraySetting"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Execute_NullDictionary_ThrowsArgumentNullException()
        {
            var dictionaryToConfig = new DictionaryToConfig
            {
                Dictionary = null
            };

            WorkflowInvoker.Invoke(dictionaryToConfig);
        }

        [TestMethod]
        public void Execute_EmptyDictionary_ReturnsEmptyConfigSection()
        {
            var dictionary = new Dictionary<string, object>();

            var dictionaryToConfig = new DictionaryToConfig
            {
                Dictionary = new InArgument<Dictionary<string, object>>(_ => dictionary)
            };

            var result = WorkflowInvoker.Invoke(dictionaryToConfig);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }
    }
}
