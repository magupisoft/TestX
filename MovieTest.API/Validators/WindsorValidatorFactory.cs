using System;

using Castle.Windsor;

using FluentValidation;

namespace MovieTest.API.Validators
{
    public class WindsorValidatorFactory : ValidatorFactoryBase
    {
        private readonly IWindsorContainer container;

        public WindsorValidatorFactory(IWindsorContainer container)
        {
            this.container = container;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            if (this.container.Kernel.HasComponent(validatorType))
            {
                return this.container.Resolve(validatorType) as IValidator;
            }
            return null;
        }
    }
}
