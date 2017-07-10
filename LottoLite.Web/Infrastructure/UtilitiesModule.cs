using LottoLite.Interfaces.Utilities;
using LottoLite.Web.Validators;
using Ninject.Modules;

namespace LottoLite.Web.Infrastructure
{

    public class UtilitiesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidationCollection>().To<ValidationCollection>();
            Bind<IValidationResult>().To<ValidationResult>();
        }
    }
}