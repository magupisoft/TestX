using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using MovieTest.Common.Interfaces.Repositories;
using MovieTest.Data.EF;
using MovieTest.Data.Repositories;

namespace MovieTest.Data.DI
{
    public class DataInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IMoviesrepository>().ImplementedBy<MoviesRepository>().LifestylePerWebRequest());
            container.Register(
                Component.For<MoviesDbContext>().LifestylePerWebRequest());
        }
    }
}
