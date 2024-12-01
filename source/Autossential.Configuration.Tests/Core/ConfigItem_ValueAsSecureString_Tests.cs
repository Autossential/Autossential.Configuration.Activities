using Autossential.Configuration.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Security;

namespace Autossential.Configuration.Tests
{

    [TestClass]
    public class ConfigItem_ValueAsSecureString_Tests
    {

        [TestMethod]
        public void ValueAsSecureString_WithValidString_ReturnsSecureString()
        {
            // Arrange
            const string expectedPlainText = "TestValue";
            var configItem = new ConfigItem("TestKey", expectedPlainText);

            // Act
            var result = configItem.ValueAsSecureString();
            var resultPlainText = new NetworkCredential(string.Empty, result).Password;

            // Assert
            Assert.AreEqual(expectedPlainText, resultPlainText);
        }

        [TestMethod]
        public void ValueAsSecureString_WithSecureString_ReturnsSameSecureString()
        {
            // Arrange
            var secureString = new SecureString();
            foreach (var c in "TestValue")
                secureString.AppendChar(c);
            var configItem = new ConfigItem("TestKey", secureString);

            // Act
            var result = configItem.ValueAsSecureString();

            // Assert
            Assert.AreEqual(secureString, result);
        }

        [TestMethod]
        public void ValueAsSecureString_WithNullValue_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", null);
            var defaultSecureString = new SecureString();
            foreach (var c in "Default")
                defaultSecureString.AppendChar(c);

            // Act
            var result = configItem.ValueAsSecureString(defaultSecureString);

            // Assert
            Assert.AreEqual(defaultSecureString, result);
        }

        [TestMethod]
        public void ValueAsSecureString_WithInvalidType_ReturnsDefaultValue()
        {
            // Arrange
            var configItem = new ConfigItem("TestKey", 12345);
            var defaultSecureString = new SecureString();
            foreach (var c in "Default")
                defaultSecureString.AppendChar(c);

            // Act
            var result = configItem.ValueAsSecureString(defaultSecureString);

            // Assert
            Assert.AreEqual(defaultSecureString, result);
        }
    }
}