using System.Collections.Generic;

namespace LottoLite.Interfaces.Entities
{
    public interface IWinningNumbers
    {
        List<int> PrimaryWinningNumbers { get; set; }
        List<int> SecondaryWinningNumbers { get; set; }
    }
}
