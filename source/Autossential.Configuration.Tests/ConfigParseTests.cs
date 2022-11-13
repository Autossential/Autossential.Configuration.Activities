using Autossential.Configuration.Activities;
using Autossential.Configuration.Core;
using Autossential.Shared.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using YamlDotNet.Core;

namespace Autossential.Configuration.Tests
{
    [TestClass]
    public class ConfigParseTests
    {
        [TestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void JsonTests(bool invalidJsonNotation)
        {
            var content = invalidJsonNotation
                ? "{ name: \"Mob\", value: 100 }"
                : "{ \"name\": \"Mob\", \"value\": 100 }";

            var args = GetArgs(content);

            if (invalidJsonNotation)
            {
                Assert.ThrowsException<JsonException>(() => WorkflowTester.Run(new ConfigParse(), args));
            }
            else
            {
                var res = WorkflowTester.Run(new ConfigParse(), args);
                var value = res.Get(p => p.Result);
                Assert.IsNotNull(value);
            }
        }

        [TestMethod]
        public void JsonArrayTest()
        {
            var content = "[{ \"name\": \"Autossential\" }]";
            var args = GetArgs(content);
            var res = WorkflowTester.Run(new ConfigParse(), args);
            var config = res.Get(p => p.Result) as ConfigSection;
            Assert.IsNotNull(config);
            Assert.IsTrue(config.HasKey("root"));
            Assert.AreEqual("Autossential", config.AsString("root/name"));
        }

        [TestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void YamlTests(bool invalidYamlNotation)
        {
            var content = invalidYamlNotation
                ? "$name: Mob\nvalue:100"
                : "name: Mob\nvalue: 100";

            var args = GetArgs(content);

            if (invalidYamlNotation)
            {
                Assert.ThrowsException<SyntaxErrorException>(() => WorkflowTester.Run(new ConfigParse(), args));
            }
            else
            {
                var res = WorkflowTester.Run(new ConfigParse(), args);
                var value = res.Get(p => p.Result);
                Assert.IsNotNull(value);
            }
        }

        private static Dictionary<string, object> GetArgs(string content)
        {
            return new Dictionary<string, object>
            {
                { nameof(ConfigParse.Content), content }
            };
        }
    }
}