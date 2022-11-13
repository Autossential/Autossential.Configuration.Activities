namespace Autossential.Configuration.Core.Resolvers
{
    public static class SectionResolverFactory
    {
        public static ISectionResolver CreateFromContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                return new JsonSectionResolver("{}");

            content = content.Trim();
            if (content.StartsWith("{") || content.StartsWith("["))
                return new JsonSectionResolver(content);

            return new YamlSectionResolver(content);
        }
    }
}
