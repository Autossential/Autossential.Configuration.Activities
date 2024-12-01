using Autossential.Configuration.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autossential.Configuration.Tests
{
    [TestClass]
    public class ConfigItem_ValueAsDecimal_Tests
    {
        [TestMethod]
        public void ValueAsDecimal_WithValidValue_ReturnsDecimal()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", "12345.67");
            var expectedValue = 12345.67m;

            // Act
            var result = configItem.ValueAsDecimal();

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void ValueAsDecimal_WithNullValue_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", null);
            var defaultValue = 42.42m;

            // Act
            var result = configItem.ValueAsDecimal(defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

        [TestMethod]
        public void ValueAsDecimal_WithInvalidValue_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", "NotADecimal");
            var defaultValue = 42.42m;

            // Act
            var result = configItem.ValueAsDecimal(defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

        [TestMethod]
        public void ValueAsDecimal_WithValidValueAndFormatProvider_ReturnsDecimal()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", "12.345,67");
            var expectedValue = 12345.67m;
            var formatProvider = new System.Globalization.CultureInfo("pt-BR");

            // Act
            var result = configItem.ValueAsDecimal(formatProvider);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void ValueAsDecimal_WithNullValueAndFormatProvider_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", null);
            var defaultValue = 42.42m;
            var formatProvider = new System.Globalization.CultureInfo("pt-BR");

            // Act
            var result = configItem.ValueAsDecimal(formatProvider, defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

        [TestMethod]
        public void ValueAsDecimal_WithInvalidValueAndFormatProvider_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", "NotADecimal");
            var defaultValue = 42.42m;
            var formatProvider = new System.Globalization.CultureInfo("pt-BR");

            // Act
            var result = configItem.ValueAsDecimal(formatProvider, defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

    }
}
