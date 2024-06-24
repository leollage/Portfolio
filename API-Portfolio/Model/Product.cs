using System.ComponentModel.DataAnnotations;

namespace API_Portfolio.Model
{
    public class Product
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public double MinimumInvestment { get; set; }
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public double Value { get; set; }
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public DateTime Vencimento { get; set; }
    }
}