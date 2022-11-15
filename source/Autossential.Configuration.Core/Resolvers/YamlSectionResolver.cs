using System.Collections.Generic;
using System.IO;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace Autossential.Configuration.Core.Resolvers
{
    public class YamlSectionResolver : DictionarySectionResolver
    {
        private readonly Deserializer _deserializer;
        private readonly IParser _yamlContent;

        public YamlSectionResolver(string yamlContent)
        {
            _deserializer = new Deserializer();
            _yamlContent = new MergingParser(new Parser(new StringReader(yamlContent)));
        }

        public override void Resolve(ConfigSection config)
        {
            var settings = _deserializer.Deserialize<Dictionary<string, object>>(_yamlContent);
            ResolveInternal(config, settings);
        }
    }
}