
namespace LottoLite.Interfaces.Utilities
{
    public interface IValidationResult
    {
        bool IsValid { get; set; }
        string Message { get; set; }
    }
}
