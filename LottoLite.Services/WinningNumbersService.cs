using LottoLite.Interfaces.Entities;
using LottoLite.Interfaces.Logger;
using LottoLite.Interfaces.Repository;
using LottoLite.Interfaces.Services;
using LottoLite.Interfaces.Utilities;
using System.Linq;

namespace LottoLite.Services
{
    public class WinningNumbersService : IWinningNumbersService
    {
        private IReadOnlyRepository<ILotteryDraw> _readOnlyRepo;
        private IWriteOnlyRepository<ILotteryDraw> _writeOnlyRepo;
        private ILotteryDrawSearchService _searchService;
        private ILogger _logger;

        public WinningNumbersService(ILotteryDrawSearchService searchService, IReadOnlyRepository<ILotteryDraw> readOnlyRepo, IWriteOnlyRepository<ILotteryDraw> writeOnlyRepo, ILogger logger)
        {
            _readOnlyRepo = readOnlyRepo;
            _writeOnlyRepo = writeOnlyRepo;
            _searchService = searchService;
            _logger = logger;
        }

        public void SetWinningNumbers(ILotteryDraw draw, IWinningNumbers winningNumbers)
        {
            draw.PrimaryWinningNumbers = winningNumbers.PrimaryWinningNumbers;
            draw.SecondaryWinningNumbers = winningNumbers.SecondaryWinningNumbers;
            _writeOnlyRepo.Update(draw);
            
            _logger.Debug(string.Format("Draw named '{0}' updated with winning numbers", draw.Name));
        }


        public IValidationCollection ValidateWinningNumbers(ILotteryDraw draw, IWinningNumbers winningNumbers, IValidationCollection results)
        {
            _logger.Debug(string.Format("Executing winning numbers validation on draw '{0}'...", draw.Name));

            if (winningNumbers.PrimaryWinningNumbers.Any(x => x > draw.PrimaryNumbersMax))
            {
                results.Add(false, "Primary number exceeds the maximum allowed");
            }
            if (winningNumbers.PrimaryWinningNumbers.Any(x => x < draw.PrimaryNumbersMin))
            {
                results.Add(false, "Primary number below the minimum allowed");
            }
            if (winningNumbers.SecondaryWinningNumbers.Any(x => x > draw.SecondaryNumbersMax))
            {
                results.Add(false, "Secondary number exceeds the maximum allowed");
            } 
            if (winningNumbers.SecondaryWinningNumbers.Any(x => x < draw.SecondaryNumbersMin))
            {
                results.Add(false, "Secondary number below the minimum allowed");
            }

            results.Where(x => !x.IsValid).ToList().ForEach((x) => { _logger.Debug(x.Message); }); // log validation failures

            return results;
        }

    }
}
