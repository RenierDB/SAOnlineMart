namespace SAOnlineMart.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }

        public Product(int id, string name, string description, decimal price)
        {
            Id = id;
            this.name = name;
            this.description = description;
            this.price = price;
        }

        public override string ToString()
        {
            return "Product ID: " + Id.ToString() + " Name: " + name + " Description: " + description + " Price: " + price.ToString();
        }
    }
}
