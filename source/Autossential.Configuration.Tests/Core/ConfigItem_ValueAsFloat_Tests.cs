using Autossential.Configuration.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autossential.Configuration.Tests
{
    [TestClass]
    public class ConfigItem_ValueAsFloat_Tests
    {
        [TestMethod]
        public void ValueAsFloat_WithValidValue_ReturnsFloat()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", "12345.67");
            var expectedValue = 12345.67f;

            // Act
            var result = configItem.ValueAsFloat();

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void ValueAsFloat_WithNullValue_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", null);
            var defaultValue = 42.42f;

            // Act
            var result = configItem.ValueAsFloat(defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

        [TestMethod]
        public void ValueAsFloat_WithInvalidValue_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", "NotAFloat");
            var defaultValue = 42.42f;

            // Act
            var result = configItem.ValueAsFloat(defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

        [TestMethod]
        public void ValueAsFloat_WithValidValueAndFormatProvider_ReturnsFloat()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", "12.345,67");
            var expectedValue = 12345.67f;
            var formatProvider = new System.Globalization.CultureInfo("pt-BR");

            // Act
            var result = configItem.ValueAsFloat(formatProvider);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void ValueAsFloat_WithNullValueAndFormatProvider_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", null);
            var defaultValue = 42.42f;
            var formatProvider = new System.Globalization.CultureInfo("pt-BR");

            // Act
            var result = configItem.ValueAsFloat(formatProvider, defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

        [TestMethod]
        public void ValueAsFloat_WithInvalidValueAndFormatProvider_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", "NotAFloat");
            var defaultValue = 42.42f;
            var formatProvider = new System.Globalization.CultureInfo("pt-BR");

            // Act
            var result = configItem.ValueAsFloat(formatProvider, defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

    }
}
