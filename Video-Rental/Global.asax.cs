using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using AutoMapper;
using Video_Rental.App_Start;

namespace Video_Rental
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //initalize automapper with mapping profile class
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
            //register web api
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
