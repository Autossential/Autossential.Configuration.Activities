using Autossential.Configuration.Activities.Properties;
using Autossential.Configuration.Core;
using System.Activities;

namespace Autossential.Configuration.Activities
{
    public sealed class MergeConfig : CodeActivity
    {
        public InOutArgument<ConfigSection> Destination { get; set; }
        public InArgument<ConfigSection> Source { get; set; }
        public InArgument<string> SectionName { get; set; }

        public bool Override { get; set; } = true;

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Destination == null) metadata.AddValidationError(Resources.Validation_ValueErrorFormat(nameof(Destination)));
            if (Source == null) metadata.AddValidationError(Resources.Validation_ValueErrorFormat(nameof(Source)));
        }

        protected override void Execute(CodeActivityContext context)
        {
            var source = Source.Get(context);
            var destination = Destination.Get(context);
            var name = SectionName.Get(context);

            if (!string.IsNullOrWhiteSpace(name) && !destination.HasSection(name))
            {
                var section = new ConfigSection();
                destination[name] = section;
                section.Merge(source, Override);
                return;
            }

            destination.Merge(source, Override);
        }
    }
}