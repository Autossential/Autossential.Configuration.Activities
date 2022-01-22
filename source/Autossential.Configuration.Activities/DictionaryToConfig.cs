using Autossential.Configuration.Core.Resolvers;
using Autossential.Configuration.Activities.Properties;
using Autossential.Configuration.Core;
using System.Activities;
using System.Collections.Generic;

namespace Autossential.Configuration.Activities
{
    public sealed class DictionaryToConfig : CodeActivity<ConfigSection>
    {
        public InArgument<Dictionary<string, object>> Dictionary { get; set; }
        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Dictionary == null) metadata.AddValidationError(Resources.Validation_ValueErrorFormat(nameof(Dictionary)));
            if (Result == null) metadata.AddValidationError(Resources.Validation_ValueErrorFormat(nameof(Result)));
        }
        protected override ConfigSection Execute(CodeActivityContext context)
        {
            var dic = Dictionary.Get(context);
            return new ConfigSection(new DictionarySectionResolver(dic));
        }
    }
}