using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using MovieTest.Domain.DI;

namespace MovieTest.Installers
{
    public class CommonInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Install(new DomainInstaller());
        }
    }
}