using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using FluentValidation;

using MovieTest.Data.DI;
using MovieTest.Domain.Handlers;

namespace MovieTest.Domain.DI
{
    public class DomainInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Install(new DataInstaller());

            container.Register(
                Classes.FromThisAssembly()
                    .BasedOn(typeof(IHandleApiRequestAsync<,>))
                    .OrBasedOn(typeof(IHandleApiRequestAsync<>))
                    .WithServiceSelf()
                    .WithService.DefaultInterfaces()
                    .WithService.FromInterface()
                    .WithServiceAllInterfaces()
                    .LifestyleTransient());

            container.Register(
                Classes.FromThisAssembly()
                   .BasedOn(typeof(AbstractValidator<>))
                   .WithServiceFirstInterface()
                   .LifestylePerWebRequest());
        }
    }
}
