using LottoLite.Interfaces.Utilities;

namespace LottoLite.Web.Validators
{
    public class ValidationResult : IValidationResult
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
    }
}