using Autossential.Configuration.Activities.Properties;
using Autossential.Configuration.Core;
using Autossential.Configuration.Core.Resolvers;
using System.Activities;
using System.IO;

namespace Autossential.Configuration.Activities
{
    public sealed class ReadConfigFile : CodeActivity<ConfigSection>
    {
        public InArgument<string> FilePath { get; set; }
        public ConfigFileType FileType { get; set; } = ConfigFileType.AutoDetect;

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (FilePath == null) metadata.AddValidationError(Resources.Validation_ValueErrorFormat(nameof(FilePath)));
            if (Result == null) metadata.AddValidationError(Resources.Validation_ValueErrorFormat(nameof(Result)));
        }

        protected override ConfigSection Execute(CodeActivityContext context)
        {
            var filePath = FilePath.Get(context);
            return new ConfigSection(GetResolver(filePath));
        }

        private ISectionResolver GetResolver(string filePath)
        {
            var content = File.ReadAllText(filePath);

            if (FileType == ConfigFileType.Yaml)
                return new YamlSectionResolver(content);

            if (FileType == ConfigFileType.Json)
                return new JsonSectionResolver(content);

            switch (Path.GetExtension(filePath).ToLowerInvariant())
            {
                case ".json": return new JsonSectionResolver(content);
                case ".yaml":
                case ".yml": return new YamlSectionResolver(content);
                default:
                    if (content.Trim().StartsWith("{"))
                        return new JsonSectionResolver(content);
                    return new YamlSectionResolver(content);
            }
        }
    }
}