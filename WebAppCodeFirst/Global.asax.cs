using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Microsoft.Practices.ServiceLocation;
using WebAppCodeFirst.DAL;
using WebAppCodeFirst.DAL.Interface;
using WebAppCodeFirst.Ioc;

namespace WebAppCodeFirst
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var iocManager = IoCConfig.IocManager(new ContainerBuilder());
            IoCConfig.IocManager(new ContainerBuilder()).SetAutofacResolver();
        }

        protected void Application_EndRequest()
        {
            var contextManager = ServiceLocator.Current.GetInstance<IContextManager<SchoolContext>>() as ContextManager<SchoolContext>;
            if (contextManager != null)
            {
                contextManager.GetContext().Dispose();
            }
        }
    }
}
