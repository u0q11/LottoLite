using LottoLite.Interfaces.Entities;
using LottoLite.Interfaces.Repository;
using LottoLite.Repository;
using Ninject.Modules;

namespace LottoLite.Web.Infrastructure
{

    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IReadOnlyRepository<ILotteryDraw>>().To<LotteryDrawRepository>();
            Bind<IWriteOnlyRepository<ILotteryDraw>>().To<LotteryDrawRepository>();
        }
    }
}