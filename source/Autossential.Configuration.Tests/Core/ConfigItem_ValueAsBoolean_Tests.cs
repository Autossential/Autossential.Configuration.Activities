using Autossential.Configuration.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autossential.Configuration.Tests
{
    [TestClass]
    public class ConfigItem_ValueAsBoolean_Tests
    {
        [TestMethod]
        public void ValueAsBoolean_WithTrueString_ReturnsTrue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", "true");

            // Act
            var result = configItem.ValueAsBoolean();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValueAsBoolean_WithFalseString_ReturnsFalse()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", "false");

            // Act
            var result = configItem.ValueAsBoolean();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValueAsBoolean_WithNullValue_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", null);
            var defaultValue = true;

            // Act
            var result = configItem.ValueAsBoolean(defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(0)]
        [DataRow(-1)]
        public void ValueAsBoolean_WithIntegerType_ReturnsSameValue(int value)
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", value);
            var defaultValue = value != 0;

            // Act
            var result = configItem.ValueAsBoolean(defaultValue);

            // Assert
            Assert.AreEqual(defaultValue, result);
        }

        [TestMethod]
        public void ValueAsBoolean_WithBooleanValue_ReturnsSameValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", true);

            // Act
            var result = configItem.ValueAsBoolean();

            // Assert
            Assert.IsTrue(result);
        }

    }
}