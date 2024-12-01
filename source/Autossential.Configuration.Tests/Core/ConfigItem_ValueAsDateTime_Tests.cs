using Autossential.Configuration.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Autossential.Configuration.Tests
{
    [TestClass]
    public class ConfigItem_ValueAsDateTime_Tests
    {
        [TestMethod]
        public void ValueAsDateTime_WithValidString_ReturnsDateTime()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", "2024-11-30");
            var expectedDateTime = new DateTime(2024, 11, 30);

            // Act
            var result = configItem.ValueAsDateTime();

            // Assert
            Assert.AreEqual(expectedDateTime, result);
        }

        [TestMethod]
        public void ValueAsDateTime_WithNullValue_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", null);
            var defaultValue = new DateTime(2024, 1, 1);

            // Act
            var result = configItem.ValueAsDateTime(defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

        [TestMethod]
        public void ValueAsDateTime_WithInvalidType_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", 12345);
            var defaultValue = new DateTime(2024, 1, 1);

            // Act
            var result = configItem.ValueAsDateTime(defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

        [TestMethod]
        public void ValueAsDateTime_WithValidStringAndFormatProvider_ReturnsDateTime()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", "11/30/2024");
            var expectedDateTime = new DateTime(2024, 11, 30);
            var formatProvider = new System.Globalization.CultureInfo("en-US");

            // Act
            var result = configItem.ValueAsDateTime(formatProvider);

            // Assert
            Assert.AreEqual(expectedDateTime, result);
        }

        [TestMethod]
        public void ValueAsDateTime_WithNullValueAndFormatProvider_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", null);
            var defaultValue = new DateTime(2024, 1, 1);
            var formatProvider = new System.Globalization.CultureInfo("pt-BR");

            // Act
            var result = configItem.ValueAsDateTime(formatProvider, defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

        [TestMethod]
        public void ValueAsDateTime_WithInvalidTypeAndFormatProvider_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", 12345);
            var defaultValue = new DateTime(2024, 1, 1);
            var formatProvider = new System.Globalization.CultureInfo("pt-BR");

            // Act
            var result = configItem.ValueAsDateTime(formatProvider, defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

    }
}
