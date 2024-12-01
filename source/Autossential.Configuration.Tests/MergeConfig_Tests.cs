using Autossential.Configuration.Activities;
using Autossential.Configuration.Core;
using Autossential.Configuration.Core.Resolvers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Activities;

namespace Autossential.Configuration.Tests
{
    [TestClass]
    public class MergeConfig_Tests
    {
        [TestMethod]
        public void Execute_MergeJsonConfigsWithOverrideTrue()
        {
            var destinationJson = @"
            {
                ""Name"": ""John Doe"",
                ""Email"": ""johndoe@example.com"",
                ""Address"": {
                    ""Street"": ""123 Elm St"",
                    ""City"": ""Springfield"",
                    ""ZipCode"": ""12345""
                }
            }";

            var sourceJson = @"
            {
                ""Name"": ""Jane Doe"",
                ""Email"": ""janedoe@example.com"",
                ""Address"": {
                    ""Street"": ""456 Oak St"",
                    ""City"": ""Springfield"",
                    ""ZipCode"": ""67890""
                }
            }";

            var sourceConfig = new ConfigSection(new JsonSectionResolver(sourceJson));
            var destinationConfig = new ConfigSection(new JsonSectionResolver(destinationJson));

            var mergeConfig = new MergeConfig
            {
                Destination = new InOutArgument<ConfigSection>(_ => destinationConfig),
                Source = new InArgument<ConfigSection>(_ => sourceConfig),
                Override = true
            };

            WorkflowInvoker.Invoke(mergeConfig);

            Assert.IsNotNull(destinationConfig);
            Assert.AreEqual("Jane Doe", destinationConfig.AsString("Name"));
            Assert.AreEqual("janedoe@example.com", destinationConfig.AsString("Email"));
            Assert.AreEqual("456 Oak St", destinationConfig.AsString("Address/Street"));
            Assert.AreEqual("Springfield", destinationConfig.AsString("Address/City"));
            Assert.AreEqual("67890", destinationConfig.AsString("Address/ZipCode"));
        }

        [TestMethod]
        public void Execute_MergeJsonConfigsWithOverrideFalse()
        {
            var destinationJson = @"
            {
                ""Name"": ""John Doe"",
                ""Email"": ""johndoe@example.com"",
                ""Address"": {
                    ""Street"": ""123 Elm St"",
                    ""City"": ""Springfield"",
                    ""ZipCode"": ""12345""
                }
            }";

            var sourceJson = @"
            {
                ""Name"": ""Jane Doe"",
                ""Email"": ""janedoe@example.com"",
                ""Address"": {
                    ""Street"": ""456 Oak St"",
                    ""City"": ""Springfield"",
                    ""ZipCode"": ""67890""
                }
            }";

            var sourceConfig = new ConfigSection(new JsonSectionResolver(sourceJson));
            var destinationConfig = new ConfigSection(new JsonSectionResolver(destinationJson));

            var mergeConfig = new MergeConfig
            {
                Destination = new InOutArgument<ConfigSection>(_ => destinationConfig),
                Source = new InArgument<ConfigSection>(_ => sourceConfig),
                Override = false
            };

            WorkflowInvoker.Invoke(mergeConfig);

            Assert.IsNotNull(destinationConfig);
            Assert.AreEqual("John Doe", destinationConfig.AsString("Name"));
            Assert.AreEqual("johndoe@example.com", destinationConfig.AsString("Email"));
            Assert.AreEqual("123 Elm St", destinationConfig.AsString("Address/Street"));
            Assert.AreEqual("Springfield", destinationConfig.AsString("Address/City"));
            Assert.AreEqual("12345", destinationConfig.AsString("Address/ZipCode"));
        }

        [TestMethod]
        public void Execute_MergeJsonConfigsWithSectionName()
        {
            var destinationJson = @"
            {
                ""Name"": ""John Doe"",
                ""Contact"": {
                    ""Phone"": ""123-456-7890"",
                    ""Email"": ""johndoe@example.com""
                }
            }";

            var sourceJson = @"
            {
                ""Contact"": {
                    ""Email"": ""janedoe@example.com""
                }
            }";

            var sourceConfig = new ConfigSection(new JsonSectionResolver(sourceJson));
            var destinationConfig = new ConfigSection(new JsonSectionResolver(destinationJson));

            var mergeConfig = new MergeConfig
            {
                Destination = new InOutArgument<ConfigSection>(_ => destinationConfig),
                Source = new InArgument<ConfigSection>(_ => sourceConfig),
                SectionName = new InArgument<string>("Contact"),
                Override = true
            };

            WorkflowInvoker.Invoke(mergeConfig);

            Assert.IsNotNull(destinationConfig);
            Assert.AreEqual("John Doe", destinationConfig.AsString("Name"));
            Assert.AreEqual("123-456-7890", destinationConfig.AsString("Contact/Phone"));
            Assert.AreEqual("janedoe@example.com", destinationConfig.AsString("Contact/Email"));
        }
    }
}