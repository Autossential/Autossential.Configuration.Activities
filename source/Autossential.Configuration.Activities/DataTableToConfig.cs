using Autossential.Configuration.Activities.Properties;
using Autossential.Configuration.Core;
using Autossential.Configuration.Core.Resolvers;
using System;
using System.Activities;
using System.Data;

namespace Autossential.Configuration.Activities
{
    public sealed class DataTableToConfig : CodeActivity<ConfigSection>
    {
        public InArgument<DataTable> DataTable { get; set; }
        public InArgument<string> KeyColumnName { get; set; }
        public InArgument<string> ValueColumnName { get; set; }

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (DataTable == null) metadata.AddValidationError(Resources.Validation_ValueErrorFormat(nameof(DataTable)));
            if (Result == null) metadata.AddValidationError(Resources.Validation_ValueErrorFormat(nameof(Result)));
            if (KeyColumnName == null) metadata.AddValidationError(Resources.Validation_ValueErrorFormat(nameof(KeyColumnName)));
            if (ValueColumnName == null) metadata.AddValidationError(Resources.Validation_ValueErrorFormat(nameof(ValueColumnName)));
        }

        protected override ConfigSection Execute(CodeActivityContext context)
        {
            var table = DataTable.Get(context) ?? throw new ArgumentNullException(nameof(DataTable));
            var key = KeyColumnName.Get(context) ?? throw new ArgumentNullException(nameof(KeyColumnName));
            var value = ValueColumnName.Get(context) ?? throw new ArgumentNullException(nameof(ValueColumnName));

            if (key == string.Empty)
                throw new ArgumentException(Resources.Validation_EmptyStringErrorFormat(nameof(KeyColumnName)));

            if (value == string.Empty)
                throw new ArgumentException(Resources.Validation_EmptyStringErrorFormat(nameof(ValueColumnName)));

            return new ConfigSection(new DataTableSectionResolver(table, key, value));
        }
    }
}