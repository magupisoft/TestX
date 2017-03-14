using System.Web.Http;
using System.Web.Http.Dispatcher;

using Castle.Windsor;

using MovieTest.API.DI;
using MovieTest.Domain;

namespace MovieTest.API
{

    public class WebApiApplication : System.Web.HttpApplication
    {
        private readonly IWindsorContainer container;

        // Since IWindsorContainer itself implements IDisposable, you should create and configure the container in the application's constructor 
        // so that you can dispose it when the application exits
        public WebApiApplication()
        {
            this.container = new WindsorContainer().Install(new WebApiInstaller());
        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorCompositionRoot(this.container));

            GlobalConfiguration.Configure(WebApiConfig.Register);

            // AutoMapper Configuration
            MapperConfiguration.Initialize();
        }
    }
}
