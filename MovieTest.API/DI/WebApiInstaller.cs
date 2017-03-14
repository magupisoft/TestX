using System.Web.Http;

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using MovieTest.Domain.DI;

namespace MovieTest.API.DI
{
    public class WebApiInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
            Classes
                .FromThisAssembly()
                .BasedOn<ApiController>()
                .LifestyleScoped());

            container.Install(new DomainInstaller());
        }
    }
}