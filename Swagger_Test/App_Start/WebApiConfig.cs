using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Cors;
using System.Web.Http.Routing;

namespace Swagger_Test
{
    public class CustomDirectRouteProvider : DefaultDirectRouteProvider
    {
        protected override IReadOnlyList<IDirectRouteFactory> GetActionRouteFactories(HttpActionDescriptor actionDescriptor)
        {
            return actionDescriptor.GetCustomAttributes<IDirectRouteFactory>(inherit: true);
        }
    }
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.AddApiVersioning(options => {
            //    options.ReportApiVersions = true;
            //});

            //var constraintResolver = new System.Web.Http.Routing.DefaultInlineConstraintResolver();
            //constraintResolver.ConstraintMap.Add("apiVersion", typeof(ApiVersionRouteConstraint));
            //config.MapHttpAttributeRoutes(constraintResolver);

            // Web API configuration and services
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            config.Formatters.Clear();
            config.Formatters.Add(new BrowserJsonFormatter());

            // Web API routes: allow route inheritance
            // See https://docs.microsoft.com/en-us/aspnet/web-api/overview/releases/whats-new-in-aspnet-web-api-22#ARI
            config.MapHttpAttributeRoutes(new CustomDirectRouteProvider());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private class BrowserJsonFormatter : JsonMediaTypeFormatter
        {
            public BrowserJsonFormatter()
            {
                this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            }

            public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
            {
                base.SetDefaultContentHeaders(type, headers, mediaType);
                headers.ContentType = new MediaTypeHeaderValue("application/json");
            }
        }
    }
}
