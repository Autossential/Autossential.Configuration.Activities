using Autossential.Configuration.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autossential.Configuration.Tests
{
    [TestClass]
    public class ConfigItem_ValueAsDouble_Tests
    {
        [TestMethod]
        public void ValueAsDouble_WithValidValue_ReturnsDouble()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", "12345.67");
            var expectedValue = 12345.67;

            // Act
            var result = configItem.ValueAsDouble();

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void ValueAsDouble_WithNullValue_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", null);
            var defaultValue = 42.42;

            // Act
            var result = configItem.ValueAsDouble(defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

        [TestMethod]
        public void ValueAsDouble_WithInvalidValue_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", "NotADouble");
            var defaultValue = 42.42;

            // Act
            var result = configItem.ValueAsDouble(defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

        [TestMethod]
        public void ValueAsDouble_WithValidValueAndFormatProvider_ReturnsDouble()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", "12.345,67");
            var expectedValue = 12345.67;
            var formatProvider = new System.Globalization.CultureInfo("pt-BR");

            // Act
            var result = configItem.ValueAsDouble(formatProvider);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void ValueAsDouble_WithNullValueAndFormatProvider_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", null);
            var defaultValue = 42.42;
            var formatProvider = new System.Globalization.CultureInfo("pt-BR");

            // Act
            var result = configItem.ValueAsDouble(formatProvider, defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

        [TestMethod]
        public void ValueAsDouble_WithInvalidValueAndFormatProvider_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", "NotADouble");
            var defaultValue = 42.42;
            var formatProvider = new System.Globalization.CultureInfo("pt-BR");

            // Act
            var result = configItem.ValueAsDouble(formatProvider, defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

    }
}
