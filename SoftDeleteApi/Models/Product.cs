namespace SoftDeleteApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "default";
        public decimal Price { get; set; }
        public bool Enabled { get; set; } = true;
    }
}
