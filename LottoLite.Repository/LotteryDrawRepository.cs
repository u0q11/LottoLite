using LottoLite.Interfaces.Entities;
using LottoLite.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace LottoLite.Repository
{
    public class LotteryDrawRepository : IReadOnlyRepository<ILotteryDraw>, IWriteOnlyRepository<ILotteryDraw>
    {
        //Just using MemoryCache here as a substitute for a DB

        private const string CACHE_KEY = "Entities";

        public void Insert(ILotteryDraw entity)
        {
            var cache = MemoryCache.Default;
            List<ILotteryDraw> draws = (cache.Get(CACHE_KEY) as List<ILotteryDraw>) ?? new List<ILotteryDraw>();
            
            draws.Add(entity);
            cache.Set(CACHE_KEY, draws, DateTimeOffset.MaxValue);
        }

        public void Update(ILotteryDraw entity)
        {
            var cache = MemoryCache.Default;
            List<ILotteryDraw> draws = (cache.Get(CACHE_KEY) as List<ILotteryDraw>) ?? new List<ILotteryDraw>();

            var drawToUpdate = draws.Where(x => x.Name == entity.Name).FirstOrDefault();
            drawToUpdate = entity;

            cache.Set(CACHE_KEY, draws, DateTimeOffset.MaxValue);
        }

        public IEnumerable<ILotteryDraw> FindAll()
        {
            var cache = MemoryCache.Default;
            return (cache.Get(CACHE_KEY) as List<ILotteryDraw>) ?? new List<ILotteryDraw>();
        }
    }
}
