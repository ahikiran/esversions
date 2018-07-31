using Autofac;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.Mvc;
using ESVersions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ESVersions
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Create your builder.
            var builder = new ContainerBuilder();            

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            
            builder.RegisterType<DataService>().As<IDataService>().SingleInstance().PreserveExistingDefaults();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
