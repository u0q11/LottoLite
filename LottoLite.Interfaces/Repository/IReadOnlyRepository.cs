using LottoLite.Interfaces.Entities;
using System.Collections.Generic;

namespace LottoLite.Interfaces.Repository
{
    public interface IReadOnlyRepository<T> where T : IEntity
    {
        IEnumerable<T> FindAll();
    }
}
