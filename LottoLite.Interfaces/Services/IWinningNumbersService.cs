using LottoLite.Interfaces.Entities;
using LottoLite.Interfaces.Utilities;

namespace LottoLite.Interfaces.Services
{
    public interface IWinningNumbersService
    {
        void SetWinningNumbers(ILotteryDraw draw, IWinningNumbers winningNumbers);

        IValidationCollection ValidateWinningNumbers(ILotteryDraw draw, IWinningNumbers winningNumbers, IValidationCollection results);
    }
}
