using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using MovieTest.Data.Repositories;

namespace MovieTest.Data.DI
{
    public class DataInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IMoviesrepository>().ImplementedBy<MoviesRepository>().LifestyleTransient());
            container.Register(
                Component.For<MoviesDbContext>().LifestyleTransient());
        }
    }
}
