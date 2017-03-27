using System.Configuration;
using System.Web.Http;
using System.Web.Http.Dispatcher;

using Castle.Windsor;

using FluentValidation.WebApi;

using Microsoft.Owin;
using MovieTest.API.DI;
using MovieTest.Domain;

using Owin;

using WindsorValidatorFactory = MovieTest.API.Validators.WindsorValidatorFactory;

[assembly: OwinStartup(typeof(MovieTest.API.Startup))]

namespace MovieTest.API
{
    public class Startup
    {
        private readonly IWindsorContainer container;

        // Since IWindsorContainer itself implements IDisposable, you should create and configure the container in the application's constructor 
        // so that you can dispose it when the application exits
        public Startup()
        {
            this.container = new WindsorContainer().Install(new WebApiInstaller());
        }

        public void Configuration(IAppBuilder appBuilder)
        {
            var httpConfiguration = new HttpConfiguration();

            // Replace IHttpControllerActivator by Custom Windsor IHttpControllerActivator type so it can resolve and inject dependencies
            httpConfiguration.Services.Replace(typeof(IHttpControllerActivator), new WindsorCompositionRoot(this.container));

            WebApiConfig.Register(httpConfiguration);

            appBuilder.UseWebApi(httpConfiguration);

            // Configure Fluent Validation
            FluentValidationModelValidatorProvider.Configure(httpConfiguration, provider => provider.ValidatorFactory = new WindsorValidatorFactory(this.container));

            var connectionString = ConfigurationManager.ConnectionStrings["MoviesDB"].ConnectionString;
            DomainInitializer.Initialize(connectionString);
        }
    }
}