using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using WebAppCodeFirst.DAL;
using WebAppCodeFirst.DAL.Interface;

namespace WebAppCodeFirst.Modules
{
    public class InfrastructureAutoFacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SchoolContext>().As<IDbContext>();
            builder.RegisterType<ContextManager<SchoolContext>>().As<IContextManager<SchoolContext>>();
        }
    }
}