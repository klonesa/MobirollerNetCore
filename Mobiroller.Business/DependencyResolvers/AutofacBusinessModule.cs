using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Mobiroller.Business.Abstract;
using Mobiroller.Business.Concrete;
using Mobiroller.Core.Utilities.Interceptors;
using Mobiroller.Data.Abstract;
using Mobiroller.Data.Concrete.EfCore;

namespace Mobiroller.Business.DependencyResolvers
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            //Services implements
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<EventManager>().As<IEventService>().SingleInstance();
            builder.RegisterType<EfEventDal>().As<IEventDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<LanguageManager>().As<ILanguageService>().SingleInstance();
            builder.RegisterType<EfLanguageDal>().As<ILanguageDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            //Autofac Dynamic Proxy kullanıldı.
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
