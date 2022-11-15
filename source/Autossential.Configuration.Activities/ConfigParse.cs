using Autossential.Configuration.Activities.Properties;
using Autossential.Configuration.Core;
using Autossential.Configuration.Core.Resolvers;
using System.Activities;

namespace Autossential.Configuration.Activities
{
    public sealed class ConfigParse : CodeActivity<ConfigSection>
    {
        public InArgument<string> Content { get; set; }
        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Content == null) metadata.AddValidationError(Resources.Validation_ValueErrorFormat(nameof(Content)));
            if (Result == null) metadata.AddValidationError(Resources.Validation_ValueErrorFormat(nameof(Result)));
        }

        protected override ConfigSection Execute(CodeActivityContext context)
        {
            var content = Content.Get(context);
            var resolver = SectionResolverFactory.CreateFromContent(content);
            return new ConfigSection(resolver);
        }
    }
}
