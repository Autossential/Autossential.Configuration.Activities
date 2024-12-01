using Autossential.Configuration.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Security;
using System.Text.RegularExpressions;

namespace Autossential.Configuration.Tests
{
    [TestClass]
    public class ConfigItem_ValueAsRegex_Tests
    {
        [TestMethod]
        public void ValueAsRegexPattern_WithValidString_ReturnsRegex()
        {
            // Arrange
            const string pattern = "TestPattern";
            var configItem = new ConfigItem("TestKey", pattern);
            var expectedRegex = new Regex(pattern);

            // Act
            var result = configItem.ValueAsRegex();

            // Assert
            Assert.AreEqual(expectedRegex.ToString(), result.ToString());
            Assert.AreEqual(expectedRegex.Options, result.Options);
        }

        [TestMethod]
        public void ValueAsRegexPattern_WithRegex_ReturnsSameRegex()
        {
            // Arrange
            var regex = new Regex("TestPattern");
            var configItem = new ConfigItem("TestKey", regex);

            // Act
            var result = configItem.ValueAsRegex();

            // Assert
            Assert.AreEqual(regex.ToString(), result.ToString());
            Assert.AreEqual(regex.Options, result.Options);
        }

        [TestMethod]
        public void ValueAsRegexPattern_WithNullValue_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", null);
            var defaultRegex = new Regex("DefaultPattern");

            // Act
            var result = configItem.ValueAsRegex(defaultRegex);

            // Assert
            Assert.AreEqual(defaultRegex.ToString(), result.ToString());
            Assert.AreEqual(defaultRegex.Options, result.Options);
        }

        [TestMethod]
        public void ValueAsRegexPattern_WithInvalidType_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", 12345);
            var defaultRegex = new Regex("DefaultPattern");

            // Act
            var result = configItem.ValueAsRegex(defaultRegex);

            // Assert
            Assert.AreEqual(defaultRegex.ToString(), result.ToString());
            Assert.AreEqual(defaultRegex.Options, result.Options);
        }

        [TestMethod]
        public void ValueAsRegexPattern_WithOptionsAndValidString_ReturnsRegex()
        {
            // Arrange
            const string pattern = "TestPattern";
            var configItem = new ConfigItem("TestKey", pattern);
            var expectedRegex = new Regex(pattern, RegexOptions.IgnoreCase);

            // Act
            var result = configItem.ValueAsRegex(RegexOptions.IgnoreCase);

            // Assert
            Assert.AreEqual(expectedRegex.ToString(), result.ToString());
            Assert.AreEqual(expectedRegex.Options, result.Options);
        }

        [TestMethod]
        public void ValueAsRegexPattern_WithOptionsAndRegex_ReturnsRegexWithNewOptions()
        {
            // Arrange
            var regex = new Regex("TestPattern", RegexOptions.Multiline);
            var configItem = new ConfigItem("TestKey", regex);
            var expectedRegex = new Regex("TestPattern", RegexOptions.IgnoreCase);

            // Act
            var result = configItem.ValueAsRegex(RegexOptions.IgnoreCase);

            // Assert
            Assert.AreEqual(expectedRegex.ToString(), result.ToString());
            Assert.AreEqual(expectedRegex.Options, result.Options);
        }

        [TestMethod]
        public void ValueAsRegexPattern_WithOptionsAndNullValue_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", null);
            var defaultRegex = new Regex("DefaultPattern", RegexOptions.IgnoreCase);

            // Act
            var result = configItem.ValueAsRegex(RegexOptions.IgnoreCase, defaultRegex);

            // Assert
            Assert.AreEqual(defaultRegex.ToString(), result.ToString());
            Assert.AreEqual(defaultRegex.Options, result.Options);
        }

        [TestMethod]
        public void ValueAsRegexPattern_WithOptionsAndInvalidType_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", 12345);
            var defaultRegex = new Regex("DefaultPattern", RegexOptions.IgnoreCase);

            // Act
            var result = configItem.ValueAsRegex(RegexOptions.IgnoreCase, defaultRegex);

            // Assert
            Assert.AreEqual(defaultRegex.ToString(), result.ToString());
            Assert.AreEqual(defaultRegex.Options, result.Options);
        }
    }
}