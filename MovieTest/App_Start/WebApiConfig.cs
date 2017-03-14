using System.Web.Http;

using FluentValidation.WebApi;

using MovieTest.App_Start;
using MovieTest.Domain.Validators;
using MovieTest.Filters;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MovieTest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Json Global Conventions
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;

            // Model State Validation Filter
            config.Filters.Add(new ValidateModelAttribute());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            // Configure Fluent Validation
            FluentValidationModelValidatorProvider.Configure(config);
        }
    }
}
