namespace API_Portfolio.Model
{
    public class Client
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public List<Product> Products { get; set; }
    }
}
