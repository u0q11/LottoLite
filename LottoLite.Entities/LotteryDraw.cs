using LottoLite.Interfaces.Entities;
using System;
using System.Collections.Generic;

namespace LottoLite.Entities
{
    public class LotteryDraw : ILotteryDraw
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateOfDraw { get; set; }

        public int TotalPrimaryNumbers { get; set; }

        public int PrimaryNumbersMin { get; set; }

        public int PrimaryNumbersMax { get; set; }

        public int TotalSecondaryNumbers { get; set; }

        public int SecondaryNumbersMin { get; set; }

        public int SecondaryNumbersMax { get; set; }

        public List<int> PrimaryWinningNumbers { get; set; }

        public List<int> SecondaryWinningNumbers { get; set; }
    
    }

}
