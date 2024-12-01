using Autossential.Configuration.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autossential.Configuration.Tests
{
    [TestClass]
    public class ConfigItem_ValueAsInt_Tests
    {
        [TestMethod]
        public void ValueAsInt_WithValidValue_ReturnsInt()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", "12345");
            var expectedValue = 12345;

            // Act
            var result = configItem.ValueAsInt();

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void ValueAsInt_WithNullValue_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", null);
            var defaultValue = 42;

            // Act
            var result = configItem.ValueAsInt(defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

        [TestMethod]
        public void ValueAsInt_WithInvalidValue_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", "NotAnInt");
            var defaultValue = 42;

            // Act
            var result = configItem.ValueAsInt(defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

        [TestMethod]
        public void ValueAsInt_WithValidValueAndFormatProvider_ReturnsInt()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", "12345");
            var expectedValue = 12345;
            var formatProvider = new System.Globalization.CultureInfo("pt-BR");

            // Act
            var result = configItem.ValueAsInt(formatProvider);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void ValueAsInt_WithNullValueAndFormatProvider_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", null);
            var defaultValue = 42;
            var formatProvider = new System.Globalization.CultureInfo("pt-BR");

            // Act
            var result = configItem.ValueAsInt(formatProvider, defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

        [TestMethod]
        public void ValueAsInt_WithInvalidValueAndFormatProvider_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", "NotAnInt");
            var defaultValue = 42;
            var formatProvider = new System.Globalization.CultureInfo("pt-BR");

            // Act
            var result = configItem.ValueAsInt(formatProvider, defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

    }
}
