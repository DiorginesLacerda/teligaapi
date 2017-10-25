using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace AquiVoto.App_Start
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{email}",
                defaults: new { email = System.Web.Http.RouteParameter.Optional }
            );

            //XML
            //config.Formatters.Remove(config.Formatters.JsonFormatter);
            //config.Formatters.XmlFormatter.SupportedMediaTypes.Add(new
            //    MediaTypeHeaderValue("text/xml"));

            //JSON
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new
                MediaTypeHeaderValue("application/json"));

        }
    }
}