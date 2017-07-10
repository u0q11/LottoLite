using LottoLite.Interfaces.Entities;
using System.Collections.Generic;

namespace LottoLite.Entities
{
    public class WinningNumbers : IEntity, IWinningNumbers
    {
        public List<int> PrimaryWinningNumbers { get; set; }

        public List<int> SecondaryWinningNumbers { get; set; }
    }
}
