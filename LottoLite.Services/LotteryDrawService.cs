using LottoLite.Interfaces.Entities;
using LottoLite.Interfaces.Logger;
using LottoLite.Interfaces.Repository;
using LottoLite.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LottoLite.Services
{
    public class LotteryDrawService : ILotteryDrawCreationService, ILotteryDrawSearchService
    {
        private IReadOnlyRepository<ILotteryDraw> _readOnlyRepo;
        private IWriteOnlyRepository<ILotteryDraw> _writeOnlyRepo;
        private ILogger _logger;

        public LotteryDrawService(IReadOnlyRepository<ILotteryDraw> readOnlyRepo, IWriteOnlyRepository<ILotteryDraw> writeOnlyRepo, ILogger logger)
        {
            _readOnlyRepo = readOnlyRepo;
            _writeOnlyRepo = writeOnlyRepo;
            _logger = logger;
        }

        public void AddDraw(ILotteryDraw Draw)
        {
            if (GetDrawByName(Draw.Name) != null) // 'Name' is unique identifier. Enforce this here
                throw new Exception(string.Format("A draw named '{0}' already exists.", Draw.Name));
            
            _writeOnlyRepo.Insert(Draw);

            _logger.Debug(string.Format("Draw named '{0}' inserted", Draw.Name));
        }

        public ILotteryDraw GetDrawByName(string name)
        {
            return _readOnlyRepo.FindAll().Where(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
        }

        public IList<ILotteryDraw> GetDrawsByDate(DateTime date)
        {
            var draws = _readOnlyRepo.FindAll().Where(x => x.DateOfDraw == date).ToList();
            _logger.Debug(string.Format("Retrieved {0} draws for date '{1}'", draws.Count, date.ToString("dd/MM/yyyy")));

            return draws;
        }

    }
}
