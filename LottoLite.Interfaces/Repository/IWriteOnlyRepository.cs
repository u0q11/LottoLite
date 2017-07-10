using LottoLite.Interfaces.Entities;

namespace LottoLite.Interfaces.Repository
{
    public interface IWriteOnlyRepository<T> where T : IEntity
    {
        void Insert(T entity);

        void Update(T entity);
    }
}
