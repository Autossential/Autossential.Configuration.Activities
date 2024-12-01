using Autossential.Configuration.Activities;
using Autossential.Configuration.Core;
using Autossential.Shared.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Activities;

namespace Autossential.Configuration.Tests
{
    [TestClass]
    public class ReadConfigFile_Tests
    {
        private string JsonConfigPath = IOSamples.GetSamplePath("config.json");
        private string YamlConfigPath = IOSamples.GetSamplePath("config.yaml");

        [TestMethod]
        public void Execute_ValidJsonFilePath_ReturnsConfigSection()
        {
            var readConfigFile = new ReadConfigFile
            {
                FilePath = new InArgument<string>(JsonConfigPath),
                FileType = ConfigFileType.Json
            };

            var result = WorkflowInvoker.Invoke(readConfigFile);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.HasSection("AppSettings"));
            Assert.AreEqual("Value1", result.AsString("AppSettings/Setting1"));
            Assert.AreEqual(10, result.AsInt("AppSettings/Setting2"));
            Assert.IsTrue(result.AsBoolean("AppSettings/Setting3"));
        }

        [TestMethod]
        public void Execute_ValidYamlFilePath_ReturnsConfigSection()
        {
            var readConfigFile = new ReadConfigFile
            {
                FilePath = new InArgument<string>(YamlConfigPath),
                FileType = ConfigFileType.Yaml
            };

            var result = WorkflowInvoker.Invoke(readConfigFile);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.HasSection("AppSettings"));
            Assert.AreEqual("Value1", result.AsString("AppSettings/Setting1"));
            Assert.AreEqual(10, result.AsInt("AppSettings/Setting2"));
            Assert.IsTrue(result.AsBoolean("AppSettings/Setting3"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Execute_NullFilePath_ThrowsArgumentNullException()
        {
            var readConfigFile = new ReadConfigFile
            {
                FilePath = null
            };

            WorkflowInvoker.Invoke(readConfigFile);
        }

        [TestMethod]
        public void Execute_AutoDetectJsonFile_ReturnsConfigSection()
        {
            var readConfigFile = new ReadConfigFile
            {
                FilePath = new InArgument<string>(JsonConfigPath),
                FileType = ConfigFileType.AutoDetect
            };

            var result = WorkflowInvoker.Invoke(readConfigFile);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.HasSection("AppSettings"));
            Assert.AreEqual("Value1", result.AsString("AppSettings/Setting1"));
            Assert.AreEqual(10, result.AsInt("AppSettings/Setting2"));
            Assert.IsTrue(result.AsBoolean("AppSettings/Setting3"));
        }

        [TestMethod]
        public void Execute_AutoDetectYamlFile_ReturnsConfigSection()
        {
            var readConfigFile = new ReadConfigFile
            {
                FilePath = new InArgument<string>(YamlConfigPath),
                FileType = ConfigFileType.AutoDetect
            };

            var result = WorkflowInvoker.Invoke(readConfigFile);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.HasSection("AppSettings"));
            Assert.AreEqual("Value1", result.AsString("AppSettings/Setting1"));
            Assert.AreEqual(10, result.AsInt("AppSettings/Setting2"));
            Assert.IsTrue(result.AsBoolean("AppSettings/Setting3"));
        }
    }
}