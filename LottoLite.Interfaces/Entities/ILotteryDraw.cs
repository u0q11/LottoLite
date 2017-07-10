using System;

namespace LottoLite.Interfaces.Entities
{
    public interface ILotteryDraw : IEntity, IWinningNumbers
    {
        string Name { get; set; }
        
        string Description { get; set; }
        
        DateTime DateOfDraw { get; set; }
        
        int TotalPrimaryNumbers { get; set; }
        
        int PrimaryNumbersMin { get; set; }
        
        int PrimaryNumbersMax { get; set; }

        int TotalSecondaryNumbers { get; set; }

        int SecondaryNumbersMin { get; set; }

        int SecondaryNumbersMax { get; set; }

    }
}
