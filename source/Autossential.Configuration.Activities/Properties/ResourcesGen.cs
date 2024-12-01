









// ################################
// THIS FILE IS AUTO-GENERATE BY T4
// ################################

namespace Autossential.Configuration.Activities.Properties
{
    using System.Resources;   
    

    public partial class Resources 
    {
        public static System.Globalization.CultureInfo Culture { get; set; }

        private static object _internalSyncObject;
        
        /// <summary>
        /// Thread safe lock object used by this class.
        /// </summary>
        public static object InternalSyncObject
        {
            get
            {
                if (_internalSyncObject is null)
                    System.Threading.Interlocked.CompareExchange(ref _internalSyncObject, new object(), null);
                
                return _internalSyncObject;
            }
        }
        private static ResourceManager _resourceManager;

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static ResourceManager ResourceManager
        {
            get
            {
                if (_resourceManager is null)
                {
                    System.Threading.Monitor.Enter(InternalSyncObject);

                    try
                    {
                        if (_resourceManager is null)
                            System.Threading.Interlocked.Exchange(ref _resourceManager, new ResourceManager("Autossential.Configuration.Activities.Properties.Resources", typeof(Resources).Assembly));
                    }
                    finally
                    {
                        System.Threading.Monitor.Exit(InternalSyncObject);
                    }
                }
                return _resourceManager;
            }
        }

        // ####### FORMATTERS ###############################################
        
        
        /// <summary>
        /// Looks up a localized string similar to 'Please provide a value for {0}.'.
        /// </summary>
        /// <param name="arg0">An object (0) to format.</param>
        /// <returns>A copy of format string in which the format items have been replaced by the String equivalent of the corresponding instances of Object in arguments.</returns>
        public static string Validation_ValueErrorFormat(object arg0)
        {
            return string.Format(Culture, Validation_ValueError, arg0);
        }

        /// <summary>
        /// Looks up a localized string similar to 'Please provide a value of type {0} for {1}.'.
        /// </summary>
        /// <param name="arg0">An object (0) to format.</param>
        /// <param name="arg1">An object (1) to format.</param>
        /// <returns>A copy of format string in which the format items have been replaced by the String equivalent of the corresponding instances of Object in arguments.</returns>
        public static string Validation_TypeErrorFormat(object arg0, object arg1)
        {
            return string.Format(Culture, Validation_TypeError, arg0, arg1);
        }

        /// <summary>
        /// Looks up a localized string similar to 'The value of {0} cannot be empty.'.
        /// </summary>
        /// <param name="arg0">An object (0) to format.</param>
        /// <returns>A copy of format string in which the format items have been replaced by the String equivalent of the corresponding instances of Object in arguments.</returns>
        public static string Validation_EmptyStringErrorFormat(object arg0)
        {
            return string.Format(Culture, Validation_EmptyStringError, arg0);
        }
   

        // ####### GETTERS ##################################################

        
        /// <summary>
        /// Looks up a localized string similar to 'FileType'.
        /// </summary>
        public static string ReadConfigFile_FileType_DisplayName => ResourceManager.GetString("ReadConfigFile_FileType_DisplayName", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Override'.
        /// </summary>
        public static string MergeConfig_Override_DisplayName => ResourceManager.GetString("MergeConfig_Override_DisplayName", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Please provide a value for {0}.'.
        /// </summary>
        public static string Validation_ValueError => ResourceManager.GetString("Validation_ValueError", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Dictionary'.
        /// </summary>
        public static string DictionaryToConfig_Dictionary_DisplayName => ResourceManager.GetString("DictionaryToConfig_Dictionary_DisplayName", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Merges two ConfigSection objects by copying the values from Source config to Destination config. This also applies to sub-sections.'.
        /// </summary>
        public static string MergeConfig_Description => ResourceManager.GetString("MergeConfig_Description", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Specifies the amount of time in milliseconds to wait for the activity to run before an error is thrown. The default value is 30000 (30s).'.
        /// </summary>
        public static string Common_Timeout => ResourceManager.GetString("Common_Timeout", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Result'.
        /// </summary>
        public static string DataTableToConfig_Result_DisplayName => ResourceManager.GetString("DataTableToConfig_Result_DisplayName", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Generates a new ConfigSection based on the specified Dictionary.'.
        /// </summary>
        public static string DictionaryToConfig_Description => ResourceManager.GetString("DictionaryToConfig_Description", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'If set, continue executing the remaining activities even if the current activity has failed.'.
        /// </summary>
        public static string Common_ContinueOnError => ResourceManager.GetString("Common_ContinueOnError", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Result'.
        /// </summary>
        public static string ConfigParse_Result_DisplayName => ResourceManager.GetString("ConfigParse_Result_DisplayName", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'The DataTable where to read the configuration from.'.
        /// </summary>
        public static string DataTableToConfig_DataTable_Description => ResourceManager.GetString("DataTableToConfig_DataTable_Description", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'DataTable'.
        /// </summary>
        public static string DataTableToConfig_DataTable_DisplayName => ResourceManager.GetString("DataTableToConfig_DataTable_DisplayName", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'KeyColumnName'.
        /// </summary>
        public static string DataTableToConfig_KeyColumnName_DisplayName => ResourceManager.GetString("DataTableToConfig_KeyColumnName_DisplayName", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'The file path where to read the configuration from.'.
        /// </summary>
        public static string ReadConfigFile_FilePath_Description => ResourceManager.GetString("ReadConfigFile_FilePath_Description", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Reference'.
        /// </summary>
        public static string InputOutput_Category => ResourceManager.GetString("InputOutput_Category", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Dictionary To Config'.
        /// </summary>
        public static string DictionaryToConfig_DisplayName => ResourceManager.GetString("DictionaryToConfig_DisplayName", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Determines if the source values will override the destination values if they already exists. This value is true by default.'.
        /// </summary>
        public static string MergeConfig_Override_Description => ResourceManager.GetString("MergeConfig_Override_Description", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'The Dictionary where to read the configuration from.'.
        /// </summary>
        public static string DictionaryToConfig_Dictionary_Description => ResourceManager.GetString("DictionaryToConfig_Dictionary_Description", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Generates a new ConfigSection based on the configuration file path.'.
        /// </summary>
        public static string ReadConfigFile_Description => ResourceManager.GetString("ReadConfigFile_Description", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Common'.
        /// </summary>
        public static string Common_Category => ResourceManager.GetString("Common_Category", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Generates a new ConfigSection based on the specified DataTable.'.
        /// </summary>
        public static string DataTableToConfig_Description => ResourceManager.GetString("DataTableToConfig_Description", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'If defined, creates a sub-section to destination object with the name specified and merge the values to it.'.
        /// </summary>
        public static string MergeConfig_SectionName_Description => ResourceManager.GetString("MergeConfig_SectionName_Description", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Output'.
        /// </summary>
        public static string Output_Category => ResourceManager.GetString("Output_Category", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'DataTable To Config'.
        /// </summary>
        public static string DataTableToConfig_DisplayName => ResourceManager.GetString("DataTableToConfig_DisplayName", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'The column in DataTable that will be use as configuration value.'.
        /// </summary>
        public static string DataTableToConfig_ValueColumnName_Description => ResourceManager.GetString("DataTableToConfig_ValueColumnName_Description", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Read Config File'.
        /// </summary>
        public static string ReadConfigFile_DisplayName => ResourceManager.GetString("ReadConfigFile_DisplayName", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'The ConfigSection object to which the source ConfigSection is merged.'.
        /// </summary>
        public static string MergeConfig_Destination_Description => ResourceManager.GetString("MergeConfig_Destination_Description", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Merge Config'.
        /// </summary>
        public static string MergeConfig_DisplayName => ResourceManager.GetString("MergeConfig_DisplayName", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'The ConfigSection object.'.
        /// </summary>
        public static string DataTableToConfig_Result_Description => ResourceManager.GetString("DataTableToConfig_Result_Description", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'FilePath'.
        /// </summary>
        public static string ReadConfigFile_FilePath_DisplayName => ResourceManager.GetString("ReadConfigFile_FilePath_DisplayName", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Source'.
        /// </summary>
        public static string MergeConfig_Source_DisplayName => ResourceManager.GetString("MergeConfig_Source_DisplayName", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Converts the text content in a ConfigSection object.'.
        /// </summary>
        public static string ConfigParse_Description => ResourceManager.GetString("ConfigParse_Description", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Text content well formatted in YAML or JSON.'.
        /// </summary>
        public static string ConfigParse_Content_Description => ResourceManager.GetString("ConfigParse_Content_Description", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'The ConfigSection object to be added to the destination ConfigSection.'.
        /// </summary>
        public static string MergeConfig_Source_Description => ResourceManager.GetString("MergeConfig_Source_Description", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Please provide a value of type {0} for {1}.'.
        /// </summary>
        public static string Validation_TypeError => ResourceManager.GetString("Validation_TypeError", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Config Parse'.
        /// </summary>
        public static string ConfigParse_DisplayName => ResourceManager.GetString("ConfigParse_DisplayName", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'The ConfigSection object.'.
        /// </summary>
        public static string DictionaryToConfig_Result_Description => ResourceManager.GetString("DictionaryToConfig_Result_Description", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Result'.
        /// </summary>
        public static string ReadConfigFile_Result_DisplayName => ResourceManager.GetString("ReadConfigFile_Result_DisplayName", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'SectionName'.
        /// </summary>
        public static string MergeConfig_SectionName_DisplayName => ResourceManager.GetString("MergeConfig_SectionName_DisplayName", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Options'.
        /// </summary>
        public static string Options_Category => ResourceManager.GetString("Options_Category", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Input'.
        /// </summary>
        public static string Input_Category => ResourceManager.GetString("Input_Category", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Destination'.
        /// </summary>
        public static string MergeConfig_Destination_DisplayName => ResourceManager.GetString("MergeConfig_Destination_DisplayName", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Result'.
        /// </summary>
        public static string DictionaryToConfig_Result_DisplayName => ResourceManager.GetString("DictionaryToConfig_Result_DisplayName", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'The ConfigSection object.'.
        /// </summary>
        public static string ReadConfigFile_Result_Description => ResourceManager.GetString("ReadConfigFile_Result_Description", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'ValueColumnName'.
        /// </summary>
        public static string DataTableToConfig_ValueColumnName_DisplayName => ResourceManager.GetString("DataTableToConfig_ValueColumnName_DisplayName", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'The column in DataTable that will be use as configuration key.'.
        /// </summary>
        public static string DataTableToConfig_KeyColumnName_Description => ResourceManager.GetString("DataTableToConfig_KeyColumnName_Description", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'The value of {0} cannot be empty.'.
        /// </summary>
        public static string Validation_EmptyStringError => ResourceManager.GetString("Validation_EmptyStringError", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'The content file type of the configuration file.'.
        /// </summary>
        public static string ReadConfigFile_FileType_Description => ResourceManager.GetString("ReadConfigFile_FileType_Description", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'Content'.
        /// </summary>
        public static string ConfigParse_Content_DisplayName => ResourceManager.GetString("ConfigParse_Content_DisplayName", Culture);
    

        /// <summary>
        /// Looks up a localized string similar to 'The ConfigSection object.'.
        /// </summary>
        public static string ConfigParse_Result_Description => ResourceManager.GetString("ConfigParse_Result_Description", Culture);
    
   

        // ####### RESOURCE NAMES ###########################################

        /// <summary>
        /// Contains all resource names stored in their respective constants.
        /// </summary>
        public static class ResourceNames
        {
            
            /// <summary>
            /// Stores the resource name 'ReadConfigFile_FileType_DisplayName'.
            /// </summary>
            public const string ReadConfigFile_FileType_DisplayName = "ReadConfigFile_FileType_DisplayName";
        

            /// <summary>
            /// Stores the resource name 'MergeConfig_Override_DisplayName'.
            /// </summary>
            public const string MergeConfig_Override_DisplayName = "MergeConfig_Override_DisplayName";
        

            /// <summary>
            /// Stores the resource name 'Validation_ValueError'.
            /// </summary>
            public const string Validation_ValueError = "Validation_ValueError";
        

            /// <summary>
            /// Stores the resource name 'DictionaryToConfig_Dictionary_DisplayName'.
            /// </summary>
            public const string DictionaryToConfig_Dictionary_DisplayName = "DictionaryToConfig_Dictionary_DisplayName";
        

            /// <summary>
            /// Stores the resource name 'MergeConfig_Description'.
            /// </summary>
            public const string MergeConfig_Description = "MergeConfig_Description";
        

            /// <summary>
            /// Stores the resource name 'Common_Timeout'.
            /// </summary>
            public const string Common_Timeout = "Common_Timeout";
        

            /// <summary>
            /// Stores the resource name 'DataTableToConfig_Result_DisplayName'.
            /// </summary>
            public const string DataTableToConfig_Result_DisplayName = "DataTableToConfig_Result_DisplayName";
        

            /// <summary>
            /// Stores the resource name 'DictionaryToConfig_Description'.
            /// </summary>
            public const string DictionaryToConfig_Description = "DictionaryToConfig_Description";
        

            /// <summary>
            /// Stores the resource name 'Common_ContinueOnError'.
            /// </summary>
            public const string Common_ContinueOnError = "Common_ContinueOnError";
        

            /// <summary>
            /// Stores the resource name 'ConfigParse_Result_DisplayName'.
            /// </summary>
            public const string ConfigParse_Result_DisplayName = "ConfigParse_Result_DisplayName";
        

            /// <summary>
            /// Stores the resource name 'DataTableToConfig_DataTable_Description'.
            /// </summary>
            public const string DataTableToConfig_DataTable_Description = "DataTableToConfig_DataTable_Description";
        

            /// <summary>
            /// Stores the resource name 'DataTableToConfig_DataTable_DisplayName'.
            /// </summary>
            public const string DataTableToConfig_DataTable_DisplayName = "DataTableToConfig_DataTable_DisplayName";
        

            /// <summary>
            /// Stores the resource name 'DataTableToConfig_KeyColumnName_DisplayName'.
            /// </summary>
            public const string DataTableToConfig_KeyColumnName_DisplayName = "DataTableToConfig_KeyColumnName_DisplayName";
        

            /// <summary>
            /// Stores the resource name 'ReadConfigFile_FilePath_Description'.
            /// </summary>
            public const string ReadConfigFile_FilePath_Description = "ReadConfigFile_FilePath_Description";
        

            /// <summary>
            /// Stores the resource name 'InputOutput_Category'.
            /// </summary>
            public const string InputOutput_Category = "InputOutput_Category";
        

            /// <summary>
            /// Stores the resource name 'DictionaryToConfig_DisplayName'.
            /// </summary>
            public const string DictionaryToConfig_DisplayName = "DictionaryToConfig_DisplayName";
        

            /// <summary>
            /// Stores the resource name 'MergeConfig_Override_Description'.
            /// </summary>
            public const string MergeConfig_Override_Description = "MergeConfig_Override_Description";
        

            /// <summary>
            /// Stores the resource name 'DictionaryToConfig_Dictionary_Description'.
            /// </summary>
            public const string DictionaryToConfig_Dictionary_Description = "DictionaryToConfig_Dictionary_Description";
        

            /// <summary>
            /// Stores the resource name 'ReadConfigFile_Description'.
            /// </summary>
            public const string ReadConfigFile_Description = "ReadConfigFile_Description";
        

            /// <summary>
            /// Stores the resource name 'Common_Category'.
            /// </summary>
            public const string Common_Category = "Common_Category";
        

            /// <summary>
            /// Stores the resource name 'DataTableToConfig_Description'.
            /// </summary>
            public const string DataTableToConfig_Description = "DataTableToConfig_Description";
        

            /// <summary>
            /// Stores the resource name 'MergeConfig_SectionName_Description'.
            /// </summary>
            public const string MergeConfig_SectionName_Description = "MergeConfig_SectionName_Description";
        

            /// <summary>
            /// Stores the resource name 'Output_Category'.
            /// </summary>
            public const string Output_Category = "Output_Category";
        

            /// <summary>
            /// Stores the resource name 'DataTableToConfig_DisplayName'.
            /// </summary>
            public const string DataTableToConfig_DisplayName = "DataTableToConfig_DisplayName";
        

            /// <summary>
            /// Stores the resource name 'DataTableToConfig_ValueColumnName_Description'.
            /// </summary>
            public const string DataTableToConfig_ValueColumnName_Description = "DataTableToConfig_ValueColumnName_Description";
        

            /// <summary>
            /// Stores the resource name 'ReadConfigFile_DisplayName'.
            /// </summary>
            public const string ReadConfigFile_DisplayName = "ReadConfigFile_DisplayName";
        

            /// <summary>
            /// Stores the resource name 'MergeConfig_Destination_Description'.
            /// </summary>
            public const string MergeConfig_Destination_Description = "MergeConfig_Destination_Description";
        

            /// <summary>
            /// Stores the resource name 'MergeConfig_DisplayName'.
            /// </summary>
            public const string MergeConfig_DisplayName = "MergeConfig_DisplayName";
        

            /// <summary>
            /// Stores the resource name 'DataTableToConfig_Result_Description'.
            /// </summary>
            public const string DataTableToConfig_Result_Description = "DataTableToConfig_Result_Description";
        

            /// <summary>
            /// Stores the resource name 'ReadConfigFile_FilePath_DisplayName'.
            /// </summary>
            public const string ReadConfigFile_FilePath_DisplayName = "ReadConfigFile_FilePath_DisplayName";
        

            /// <summary>
            /// Stores the resource name 'MergeConfig_Source_DisplayName'.
            /// </summary>
            public const string MergeConfig_Source_DisplayName = "MergeConfig_Source_DisplayName";
        

            /// <summary>
            /// Stores the resource name 'ConfigParse_Description'.
            /// </summary>
            public const string ConfigParse_Description = "ConfigParse_Description";
        

            /// <summary>
            /// Stores the resource name 'ConfigParse_Content_Description'.
            /// </summary>
            public const string ConfigParse_Content_Description = "ConfigParse_Content_Description";
        

            /// <summary>
            /// Stores the resource name 'MergeConfig_Source_Description'.
            /// </summary>
            public const string MergeConfig_Source_Description = "MergeConfig_Source_Description";
        

            /// <summary>
            /// Stores the resource name 'Validation_TypeError'.
            /// </summary>
            public const string Validation_TypeError = "Validation_TypeError";
        

            /// <summary>
            /// Stores the resource name 'ConfigParse_DisplayName'.
            /// </summary>
            public const string ConfigParse_DisplayName = "ConfigParse_DisplayName";
        

            /// <summary>
            /// Stores the resource name 'DictionaryToConfig_Result_Description'.
            /// </summary>
            public const string DictionaryToConfig_Result_Description = "DictionaryToConfig_Result_Description";
        

            /// <summary>
            /// Stores the resource name 'ReadConfigFile_Result_DisplayName'.
            /// </summary>
            public const string ReadConfigFile_Result_DisplayName = "ReadConfigFile_Result_DisplayName";
        

            /// <summary>
            /// Stores the resource name 'MergeConfig_SectionName_DisplayName'.
            /// </summary>
            public const string MergeConfig_SectionName_DisplayName = "MergeConfig_SectionName_DisplayName";
        

            /// <summary>
            /// Stores the resource name 'Options_Category'.
            /// </summary>
            public const string Options_Category = "Options_Category";
        

            /// <summary>
            /// Stores the resource name 'Input_Category'.
            /// </summary>
            public const string Input_Category = "Input_Category";
        

            /// <summary>
            /// Stores the resource name 'MergeConfig_Destination_DisplayName'.
            /// </summary>
            public const string MergeConfig_Destination_DisplayName = "MergeConfig_Destination_DisplayName";
        

            /// <summary>
            /// Stores the resource name 'DictionaryToConfig_Result_DisplayName'.
            /// </summary>
            public const string DictionaryToConfig_Result_DisplayName = "DictionaryToConfig_Result_DisplayName";
        

            /// <summary>
            /// Stores the resource name 'ReadConfigFile_Result_Description'.
            /// </summary>
            public const string ReadConfigFile_Result_Description = "ReadConfigFile_Result_Description";
        

            /// <summary>
            /// Stores the resource name 'DataTableToConfig_ValueColumnName_DisplayName'.
            /// </summary>
            public const string DataTableToConfig_ValueColumnName_DisplayName = "DataTableToConfig_ValueColumnName_DisplayName";
        

            /// <summary>
            /// Stores the resource name 'DataTableToConfig_KeyColumnName_Description'.
            /// </summary>
            public const string DataTableToConfig_KeyColumnName_Description = "DataTableToConfig_KeyColumnName_Description";
        

            /// <summary>
            /// Stores the resource name 'Validation_EmptyStringError'.
            /// </summary>
            public const string Validation_EmptyStringError = "Validation_EmptyStringError";
        

            /// <summary>
            /// Stores the resource name 'ReadConfigFile_FileType_Description'.
            /// </summary>
            public const string ReadConfigFile_FileType_Description = "ReadConfigFile_FileType_Description";
        

            /// <summary>
            /// Stores the resource name 'ConfigParse_Content_DisplayName'.
            /// </summary>
            public const string ConfigParse_Content_DisplayName = "ConfigParse_Content_DisplayName";
        

            /// <summary>
            /// Stores the resource name 'ConfigParse_Result_Description'.
            /// </summary>
            public const string ConfigParse_Result_Description = "ConfigParse_Result_Description";
        

        }
    }
}
    

