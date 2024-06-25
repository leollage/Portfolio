namespace API_Portfolio.Model
{
    public class Client
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Idade { get; set; }
        public List<Product> Products { get; set; }
    }
}
