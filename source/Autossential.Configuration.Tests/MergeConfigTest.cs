using Autossential.Configuration.Activities;
using Autossential.Configuration.Core.Resolvers;
using Autossential.Configuration.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Activities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autossential.Shared.Tests;

namespace Autossential.Configuration.Tests
{
    [TestClass]
    public class MergeConfigTest
    {
        private ConfigSection _config;
        private ConfigSection _config2;

        [TestInitialize]
        public void Initialize()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            _config = new ConfigSection(new YamlSectionResolver(File.ReadAllText(IOSamples.GetSamplePath("primary.yml"))));
            _config2 = new ConfigSection(new JsonSectionResolver(File.ReadAllText(IOSamples.GetSamplePath("secondary.json"))));
        }


        [TestMethod]
        [DataRow(null)]
        [DataRow("BrandNewSection")]
        public void Merge(string name)
        {
            var args = new Dictionary<string, object> {
                { "Source", _config2 },
                { "Destination", _config },
                { "SectionName", name }
            };

            var result = WorkflowTester.Run(new MergeConfig
            {
                Override = true
            }, args);

            Assert.IsNotNull(_config);
            Assert.AreSame(_config, (ConfigSection)result.Get(p => p.Destination));
        }
    }
}
