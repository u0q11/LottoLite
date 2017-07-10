using LottoLite.Web.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace LottoLite.Web.Models
{
    public class LotteryDrawModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [DateRequired]
        public DateTime DateOfDraw { get; set; }

        [Range(1, int.MaxValue)]
        public int TotalPrimaryNumbers { get; set; }

        [Range(1, int.MaxValue)]
        public int PrimaryNumbersMin { get; set; }

        [Range(1, int.MaxValue)]
        public int PrimaryNumbersMax { get; set; }

        [Range(1, int.MaxValue)]
        public int TotalSecondaryNumbers { get; set; }

        [Range(1, int.MaxValue)]
        public int SecondaryNumbersMin { get; set; }

        [Range(1, int.MaxValue)]
        public int SecondaryNumbersMax { get; set; }

    }
}