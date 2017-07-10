using LottoLite.Interfaces.Utilities;

namespace LottoLite.Web.Validators
{
    public class ValidationFactory
    {
        public static IValidationResult CreateResult(bool isValid, string message)
        {
            return new ValidationResult() { IsValid = isValid, Message = message };
        }

        public static IValidationCollection CreateCollection()
        {
            return new ValidationCollection();
        }
    }
}