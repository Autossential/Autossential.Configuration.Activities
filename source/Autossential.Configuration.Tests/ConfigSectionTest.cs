using Autossential.Configuration.Core.Resolvers;
using Autossential.Configuration.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Autossential.Shared.Tests;

namespace Autossential.Configuration.Tests
{
    [TestClass]
    public class ConfigSectionTest
    {
        private ConfigSection _config;

        [TestInitialize]
        public void Initialize()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            var content = File.ReadAllText(IOSamples.GetSamplePath("primary.yml"));
            _config = new ConfigSection(new YamlSectionResolver(content));
        }

        [TestMethod]
        public void Overall()
        {
            Assert.AreEqual(10, _config.Count);
            Assert.IsTrue(_config.HasSection("sub-section"));
            Assert.IsTrue(_config.HasSection("sub-section/sub-section"));
            Assert.AreEqual(10, _config.AsInt("int"));
            Assert.AreEqual(10.10d, _config.AsDouble("double"));
            Assert.AreEqual(10.15m, _config.AsDecimal("decimal"));
            Assert.AreEqual(10.20f, _config.AsFloat("float"));
            Assert.AreEqual(20, _config.AsLong("long"));
            Assert.AreEqual(new DateTime(2021, 12, 11, 17, 23, 0), _config.AsDateTime("datetime"));
            Assert.IsTrue(_config.AsBoolean("boolean"));
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, _config.AsArray<int>("array"));
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3 }, _config.AsList<int>("list"));
        }

        [TestMethod]
        public void Merge()
        {
            var content = File.ReadAllText(IOSamples.GetSamplePath("secondary.json"));
            var other = new ConfigSection(new JsonSectionResolver(content));
            _config.Merge(other, true);
            Assert.AreEqual(1000, _config.AsInt("int"));
            Assert.IsFalse(_config.AsBoolean("boolean"));
            Assert.AreEqual(2, _config.AsInt("sub-section/level"));
            Assert.AreEqual("json", _config.AsString("sub-section/name"));
        }

        [TestMethod]
        public void AddingNewValues()
        {
            _config["test"] = 1;
            _config["new-section/test"] = "hello";
            Assert.AreEqual(1, _config.AsInt("test"));
            Assert.IsTrue(_config.HasSection("new-section"));
            Assert.AreEqual("hello", _config.AsString("new-section/test"));
        }

        [TestMethod]
        public void DeleteKey()
        {
            Assert.IsTrue(_config.HasKey("double"));
            _config["double"] = null;
            Assert.IsFalse(_config.HasKey("double"));
            _config["not-a-key"] = null;
        }

        [TestMethod]
        public void InvalidSectionEntry()
        {
            try
            {
                var key = _config["not-valid"];
                var multiLevel = _config["invalid-section/key"];
                var section = _config.Section("this-path/does/not/exist");
                Assert.IsNull(key);
                Assert.IsNull(multiLevel);
                Assert.IsNull(section);
            }
            catch (Exception)
            {
                Assert.Fail("Exception thrown");
            }
        }

        [TestMethod]
        [DataRow("data", "data")]
        [DataRow("settings/runner", "runner")]
        [DataRow("systems/app/credentials", "credentials")]
        public void AutoName(string keyPath, string name)
        {
            _config[keyPath] = new ConfigSection();
            Assert.IsTrue(_config.HasSection(keyPath));
            var config = _config.Section(keyPath);
            Assert.AreEqual(name, config.Name);
            Assert.AreEqual(keyPath, config.UniqueName);
        }

        [TestMethod]
        public void GetByIndex()
        {
            Assert.IsNull(_config.Section(50));
            Assert.IsNotNull(_config.Section(_config.Count - 1));
        }
    }
}