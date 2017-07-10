using LottoLite.Interfaces.Logger;
using LottoLite.Interfaces.Services;
using LottoLite.Services;
using Ninject.Modules;

namespace LottoLite.Web.Infrastructure
{

    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILotteryDrawSearchService>().To<LotteryDrawService>();
            Bind<ILotteryDrawCreationService>().To<LotteryDrawService>();
            Bind<IWinningNumbersService>().To<WinningNumbersService>();

            //logging
            Bind<ILogger>().To<LoggerService>().InSingletonScope();
        }
    }
}