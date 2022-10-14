using Autossential.Configuration.Core.Resolvers;
using Autossential.Configuration.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Autossential.Shared.Tests;
using System.Collections.Generic;

namespace Autossential.Configuration.Tests
{

    [TestClass]
    public class YamlConfigTest
    {
        static readonly string FileSample = File.ReadAllText(IOSamples.GetSamplePath("sample.yml"));
        static readonly string ComplexSample = File.ReadAllText(IOSamples.GetSamplePath("complex.yml"));

        [TestMethod]
        public void Keys()
        {
            var keys = new[] { "Name", "Section/A", "Section/B", "Array", "Date", "Number", "Boolean" };
            var config = new ConfigSection(new YamlSectionResolver(FileSample));
            foreach (var key in keys)
                Assert.IsTrue(config.HasKey(key), key + " not found");
        }

        [TestMethod]
        public void Values()
        {
            var config = new ConfigSection(new YamlSectionResolver(FileSample));

            Assert.AreEqual("MyName", config.AsString("Name"));
            Assert.AreEqual("ValueA", config.AsString("Section/A"));
            Assert.AreEqual("ValueB", config.AsString("Section/B"));
            Assert.AreEqual(new DateTime(1983, 7, 30), config.AsDateTime("Date"));
            Assert.AreEqual(10, config.AsInt("Number"));
            Assert.IsTrue(config.AsBoolean("Boolean"));

            CollectionAssert.AreEqual(new[] { "msedge", "excel" }, config.AsArray("Array"));
        }

        [TestMethod]
        public void Advanced()
        {
            var sample = File.ReadAllText(IOSamples.GetSamplePath("advanced.yml"));
            var config = new ConfigSection(new YamlSectionResolver(sample));

            Assert.IsTrue(config.HasSection("level-1"));
            Assert.IsTrue(config.HasSection("level-1/level-2"));
            Assert.IsTrue(config.HasKey("level-1/level-2/level-3"));

            Assert.IsTrue(config.HasSection("sub-1"));
            Assert.IsTrue(config.HasSection("sub-1/sub-2"));
            Assert.IsTrue(config.HasKey("sub-1/sub-2/sub-3"));
        }

        [TestMethod]
        public void Complex()
        {
            var config = new ConfigSection(new YamlSectionResolver(ComplexSample));
            var components = config.AsArray("root/components");
            Assert.AreEqual(3, components.Length);
            Assert.AreEqual(typeof(Dictionary<object, object>), components[2].GetType());

            var containers = config.AsArray<Dictionary<object, object>>("root/spec/containers");
            Assert.AreEqual(2, containers.Length);
        }
    }
}