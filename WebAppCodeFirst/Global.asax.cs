using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.ServiceLocation;
using WebAppCodeFirst.DAL;
using WebAppCodeFirst.DAL.Interface;

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
