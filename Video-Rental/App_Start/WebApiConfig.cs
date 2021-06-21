using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Video_Rental
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //correct json formatting for javascript consuption (camel case)
            var JsonSettings = config.Formatters.JsonFormatter.SerializerSettings;
            JsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            JsonSettings.Formatting = Formatting.Indented;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
