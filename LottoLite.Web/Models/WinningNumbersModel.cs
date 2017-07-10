using System.ComponentModel.DataAnnotations;

namespace LottoLite.Web.Models
{
    public class WinningNumbersModel
    {
        [Required]
        public string DrawName { get; set; }

        public int PrimaryFirst { get; set; }
        public int PrimarySecond { get; set; }
        public int PrimaryThird { get; set; }
        public int PrimaryFourth { get; set; }
        public int PrimaryFifth { get; set; }

        public int SecondaryFirst { get; set; }
        public int SecondarySecond { get; set; }
    }
}