using LottoLite.Interfaces.Entities;
using System;
using System.Collections.Generic;

namespace LottoLite.Interfaces.Services
{
    public interface ILotteryDrawSearchService
    {
        ILotteryDraw GetDrawByName(string name);

        IList<ILotteryDraw> GetDrawsByDate(DateTime date);
    }
}
