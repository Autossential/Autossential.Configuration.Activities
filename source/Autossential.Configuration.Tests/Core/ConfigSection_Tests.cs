using Autossential.Configuration.Core;
using Autossential.Configuration.Core.Resolvers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Autossential.Configuration.Tests
{

    [TestClass]
    public class ConfigSection_Tests
    {
        [TestMethod]
        public void AsString_WithDefaultValue_ReturnsDefault()
        {
            var rules = new Dictionary<string, object>
            {
                { "data", "123" }
            };

            var c = new ConfigSection(new DictionarySectionResolver(rules));
            var section = new ConfigSection();
            var result = section.AsString("testKey", "defaultValue");
            Assert.AreEqual("defaultValue", result);
        }
    }
}
