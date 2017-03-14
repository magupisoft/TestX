using System.Web.Http;

using MovieTest.Domain;

namespace MovieTest.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // AutoMapper Configuration
            MapperConfiguration.Initialize();
        }
    }
}
