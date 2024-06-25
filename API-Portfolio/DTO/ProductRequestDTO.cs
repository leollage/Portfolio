using System.ComponentModel.DataAnnotations;

namespace API_Portfolio.DTO
{
    public class ProductRequestDTO
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double MinimumInvestment { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Valor { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime Vencimento { get; set; }
    }
}
