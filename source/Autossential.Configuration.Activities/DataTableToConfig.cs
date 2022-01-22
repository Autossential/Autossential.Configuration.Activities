using Autossential.Configuration.Core.Resolvers;
using Autossential.Configuration.Activities.Properties;
using Autossential.Configuration.Core;
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
            var table = DataTable.Get(context);
            var key = KeyColumnName.Get(context);
            var value = ValueColumnName.Get(context);

            return new ConfigSection(new DataTableSectionResolver(table, key, value));
        }
    }
}