using Autossential.Configuration.Core.Resolvers;
using Autossential.Configuration.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Autossential.Configuration.Tests
{
    [TestClass]
    public class DictionaryConfigTest
    {
        private static readonly Dictionary<string, object> _dic = new Dictionary<string, object>();

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _dic.Add("A", "ValueA");
            _dic.Add("B", "ValueB");
            _dic.Add("C", 10);
            _dic.Add("D", true);
            _dic.Add("E", new DateTime(1983, 7, 30));
            _dic.Add("F", new Dictionary<string, object>
            {
                { "A", 1 }
            });
            _dic.Add("G", new Exception("I'm an Exception object"));
        }

        [TestMethod]
        public void Keys()
        {
            var config = new ConfigSection(new DictionarySectionResolver(_dic));
            var keys = new string[] { "A", "B", "C", "D", "E", "F", "F/A", "G" };
            foreach (var key in keys)
                Assert.IsTrue(config.HasKey(key), key + " not found");
        }

        [TestMethod]
        public void Values()
        {
            var config = new ConfigSection(new DictionarySectionResolver(_dic));

            Assert.AreEqual("ValueA", config.AsString("A"));
            Assert.AreEqual("ValueB", config.AsString("B"));
            Assert.AreEqual(10, config.AsInt("C"));
            Assert.IsTrue(config.AsBoolean("D"));
            Assert.AreEqual(new DateTime(1983, 7, 30), config.AsDateTime("E"));
            Assert.IsInstanceOfType(config["F"], typeof(ConfigSection));
            Assert.AreEqual(1, config.AsInt("F/A"));
            Assert.IsInstanceOfType(config["G"], typeof(Exception));
        }
    }
}
