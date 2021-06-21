using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Mobiroller.Core.CrossCuttingConcerns.Caching;
using Mobiroller.Core.CrossCuttingConcerns.Caching.Microsoft;
using Mobiroller.Core.Utilities.IoC;

namespace Mobiroller.Core.DependencyResolvers
{
    public class CoreModule:ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            serviceCollection.AddLocalization(options => options.ResourcesPath = "Resources");

            serviceCollection.AddMemoryCache();

            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>(); //Farklı bir caching implemente edeceğimiz zaman bu kısmı değiştirmek yeterlidir.
        }
    }
}
