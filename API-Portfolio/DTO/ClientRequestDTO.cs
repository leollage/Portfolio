using System.ComponentModel.DataAnnotations;

namespace API_Portfolio.Model
{
    public class ClientRequestDTO
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Password { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Age { get; set; }
        public List<Product> Products { get; set; }
    }
}
