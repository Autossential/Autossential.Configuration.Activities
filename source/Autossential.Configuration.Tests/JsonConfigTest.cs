using Autossential.Configuration.Core;
using Autossential.Configuration.Core.Resolvers;
using Autossential.Shared.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Autossential.Configuration.Tests
{
    [TestClass]
    public class JsonConfigTest
    {
        static readonly string FileSample = File.ReadAllText(IOSamples.GetSamplePath("sample.json"));
        static readonly string ComplexSample = File.ReadAllText(IOSamples.GetSamplePath("complex.json"));

        [TestMethod]
        public void Keys()
        {
            var keys = new[] { "Name", "Section/A", "Section/B", "Array", "Date", "Number", "Boolean" };
            var config = new ConfigSection(new JsonSectionResolver(FileSample));
            foreach (var key in keys)
                Assert.IsTrue(config.HasKey(key), key + " not found");
        }

        [TestMethod]
        public void Values()
        {
            var config = new ConfigSection(new JsonSectionResolver(FileSample));

            Assert.AreEqual("MyName", config.AsString("Name"));
            Assert.AreEqual("ValueA", config.AsString("Section/A"));
            Assert.AreEqual("ValueB", config.AsString("Section/B"));
            Assert.AreEqual(new DateTime(1983, 7, 30), config.AsDateTime("Date"));
            Assert.AreEqual(10, config.AsInt("Number"));
            Assert.IsTrue(config.AsBoolean("Boolean"));

            CollectionAssert.AreEqual(new[] { "msedge", "excel" }, config.AsArray("Array"));
        }

        [TestMethod]
        public void Complex()
        {
            var config = new ConfigSection(new JsonSectionResolver(ComplexSample));
            var components = config.AsArray("root/components");
            Assert.AreEqual(3, components.Length);
            Assert.AreEqual(typeof(Dictionary<string, object>), components[2].GetType());

            var containers = config.AsArray<Dictionary<string, object>>("root/spec/containers");
            Assert.AreEqual(2, containers.Length);
        }
    }
}