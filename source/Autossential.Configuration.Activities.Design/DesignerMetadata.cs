﻿using Autossential.Configuration.Activities.Design.Designers;
using Autossential.Configuration.Activities.Properties;
using Autossential.Shared.Activities.Design;
using System.Activities.Presentation.Metadata;
using System.ComponentModel;

namespace Autossential.Configuration.Activities.Design
{
    public class DesignerMetadata : IRegisterMetadata
    {
        public const string MAIN_CATEGORY = "Autossential";
        public const string CONFIGURATION_CATEGORY = MAIN_CATEGORY + ".Configuration";
        public const string CONFIGURATION_ADAPTERS_CATEGORY = CONFIGURATION_CATEGORY + ".Adapters";

        public void Register()
        {
            var configuration = new CategoryAttribute(CONFIGURATION_CATEGORY);
            var adapters = new CategoryAttribute(CONFIGURATION_ADAPTERS_CATEGORY);

            ActivitiesAttributesBuilder.Build(Resources.ResourceManager, builder =>
            {
                builder.SetDefaultCategories(
                    Resources.Input_Category,
                    Resources.Output_Category,
                    Resources.InputOutput_Category,
                    Resources.Options_Category);

                builder.Register<ReadConfigFile, ReadConfigFileDesigner>(configuration);
                builder.Register<MergeConfig, MergeConfigDesigner>(configuration);
                builder.Register<DataTableToConfig, DataTableToConfigDesigner>(adapters);
                builder.Register<DictionaryToConfig, DictionaryToConfigDesigner>(adapters);
            });
        }
    }
}