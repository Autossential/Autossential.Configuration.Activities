using Autossential.Configuration.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autossential.Configuration.Tests
{
    [TestClass]
    public class ConfigItem_ValueAsString_Tests
    {
        [TestMethod]
        public void ValueAsString_WithValidValue_ReturnsString()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", 12345);
            var expectedValue = "12345";

            // Act
            var result = configItem.ValueAsString();

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void ValueAsString_WithNullValue_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", null);
            var defaultValue = "DefaultValue";

            // Act
            var result = configItem.ValueAsString(defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

        [TestMethod]
        public void ValueAsString_WithObjectValue_ReturnsString()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", new { Name = "Test" });
            var expectedValue = "{ Name = Test }";

            // Act
            var result = configItem.ValueAsString();

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

    }
}
