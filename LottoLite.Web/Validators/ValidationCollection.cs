using LottoLite.Interfaces.Utilities;
using System.Collections.Generic;

namespace LottoLite.Web.Validators
{
    public class ValidationCollection : List<IValidationResult>, IValidationCollection
    {
        public void Add(bool isValid, string message) // just implement our additional 'add'
        {
            base.Add(ValidationFactory.CreateResult(isValid, message));
        }
    }
}