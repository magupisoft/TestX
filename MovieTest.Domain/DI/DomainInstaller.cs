using AutoMapper;

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using MovieTest.Common.Interfaces.Handlers;
using MovieTest.Data.DI;
using MovieTest.Domain.Handlers;
using MovieTest.Domain.Mapping;

namespace MovieTest.Domain.DI
{
    public class DomainInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Install(new DataInstaller());

            container.Register(
                Component.For<IAddMovieHandler>().ImplementedBy<AddMovieHandler>().LifestyleTransient().OnlyNewServices(),
                Component.For<IUpdateMovieHandler>().ImplementedBy<UpdateMovieHandler>().LifestyleTransient().OnlyNewServices(),
                Component.For<IGetMovieHandler>().ImplementedBy<GetMovieHandler>().LifestyleTransient().OnlyNewServices(),
                Component.For<IGetMovieListHandler>().ImplementedBy<GetMovieListHandler>().LifestyleTransient().OnlyNewServices(),
                Component.For<IRemoveMovieHandler>().ImplementedBy<RemoveMovieHandler>().LifestyleTransient().OnlyNewServices());

            // Configure container by convention
            //container.Register(
            //    Classes.FromThisAssembly()
            //        .BasedOn(typeof(IHandleApiRequestAsync<,>))
            //        .OrBasedOn(typeof(IHandleApiRequestAsync<>))
            //        .WithServiceSelf()
            //        .WithService.DefaultInterfaces()
            //        .WithService.FromInterface()
            //        .WithServiceAllInterfaces()
            //        .LifestyleTransient());

            // register Automapper profiles
            container.Register(Component.For<IMapper>().UsingFactoryMethod(x =>
            {
                return new MapperConfiguration(c =>
                {
                    c.AddProfile<MoviesProfile>();
                }).CreateMapper();
            }));
        }
    }
}
