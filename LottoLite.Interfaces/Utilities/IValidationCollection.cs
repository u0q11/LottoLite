using System.Collections.Generic;

namespace LottoLite.Interfaces.Utilities
{
    public interface IValidationCollection : IList<IValidationResult>
    {
        void Add(bool isValid, string message);
    }
}
