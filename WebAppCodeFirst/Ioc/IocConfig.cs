using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Practices.ServiceLocation;
using WebAppCodeFirst.Modules;
using Autofac.Extras.CommonServiceLocator;


namespace WebAppCodeFirst.Ioc
{
    public class IoCConfig
    {
        private static ContainerBuilder _builder;

        private static IoCConfig _ioCManager;

        protected static object localObj=new object();

        private IoCConfig()
        {
            
        }

        public static IoCConfig IocManager(ContainerBuilder builder)
        {
            if (_ioCManager==null)
            {
                lock (localObj)
                {
                    if (_ioCManager==null)
                    {
                        _builder = builder;
                        _ioCManager = new IoCConfig();
                    }
                }
                
            }
            return _ioCManager;
        }

        private  void RegisterModule()
        {
            _builder.RegisterControllers();
            _builder.RegisterFilterProvider();
            _builder.RegisterModule<InfrastructureAutoFacModule>();
        }

        public void SetAutofacResolver()
        {
            RegisterModule();
            var container = _builder.Build();
          //  DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
           
            // Set the service locator to an AutofacServiceLocator.
            //var csl = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));

        }

 


    }
}