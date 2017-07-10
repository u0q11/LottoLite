using LottoLite.Interfaces.Entities;

namespace LottoLite.Interfaces.Services
{
    public interface ILotteryDrawCreationService
    {
        void AddDraw(ILotteryDraw Draw);
    }
}
