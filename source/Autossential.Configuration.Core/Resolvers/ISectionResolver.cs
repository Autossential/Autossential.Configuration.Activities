using Autossential.Configuration.Core;

namespace Autossential.Configuration.Core.Resolvers
{
    public interface ISectionResolver
    {
        void Resolve(ConfigSection config);
    }
}