using Microsoft.Extensions.DependencyInjection;

namespace Mobiroller.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
