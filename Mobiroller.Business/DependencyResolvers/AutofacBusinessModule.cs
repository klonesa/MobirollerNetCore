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
            builder.RegisterType<EventTrManager>().As<IEventTrService>().SingleInstance();
            builder.RegisterType<EfEventTrDal>().As<IEventTrDal>().SingleInstance();

            //EventIt implements
            builder.RegisterType<EventItManager>().As<IEventItService>().SingleInstance();
            builder.RegisterType<EfEventItDal>().As<IEventItDal>().SingleInstance();
        }
    }
}
