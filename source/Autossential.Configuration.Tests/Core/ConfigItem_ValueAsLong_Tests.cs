using Autossential.Configuration.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autossential.Configuration.Tests
{
    [TestClass]
    public class ConfigItem_ValueAsLong_Tests
    {
        [TestMethod]
        public void ValueAsLong_WithValidValue_ReturnsLong()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", "123456789012345");
            var expectedValue = 123456789012345L;

            // Act
            var result = configItem.ValueAsLong();

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void ValueAsLong_WithNullValue_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", null);
            var defaultValue = 424242424242L;

            // Act
            var result = configItem.ValueAsLong(defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

        [TestMethod]
        public void ValueAsLong_WithInvalidValue_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", "NotALong");
            var defaultValue = 424242424242L;

            // Act
            var result = configItem.ValueAsLong(defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

        [TestMethod]
        public void ValueAsLong_WithValidValueAndFormatProvider_ReturnsLong()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", "123456789012345");
            var expectedValue = 123456789012345L;
            var formatProvider = new System.Globalization.CultureInfo("en-US");

            // Act
            var result = configItem.ValueAsLong(formatProvider);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void ValueAsLong_WithNullValueAndFormatProvider_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", null);
            var defaultValue = 424242424242L;
            var formatProvider = new System.Globalization.CultureInfo("en-US");

            // Act
            var result = configItem.ValueAsLong(formatProvider, defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

        [TestMethod]
        public void ValueAsLong_WithInvalidValueAndFormatProvider_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", "NotALong");
            var defaultValue = 424242424242L;
            var formatProvider = new System.Globalization.CultureInfo("en-US");

            // Act
            var result = configItem.ValueAsLong(formatProvider, defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

    }
}
