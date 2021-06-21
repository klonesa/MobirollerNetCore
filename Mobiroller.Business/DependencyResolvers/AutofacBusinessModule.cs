using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Mobiroller.Business.Abstract;
using Mobiroller.Business.Concrete;
using Mobiroller.Data.Abstract;
using Mobiroller.Data.Concrete.EfCore;

namespace Mobiroller.Business.DependencyResolvers
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            //User implements
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<EventManager>().As<IEventService>().SingleInstance();
            builder.RegisterType<EfEventDal>().As<IEventDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

        }
    }
}
