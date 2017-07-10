using LottoLite.Web.Validation;
using System;

namespace LottoLite.Web.Models
{
    public class LotteryDrawSearchModel
    {
        [DateRequired]
        public DateTime Date { get; set; }
    }
}