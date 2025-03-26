using System.Text.Json.Serialization;

namespace TheBookHaven2.Models
{
    public class Order
{
        public int Id { get; set; }
        public int CustomerId { get; set; }

        [JsonIgnore]
        public Customer Customer { get; set; } = default!;
        public List<OrderDetails> OrderDetails { get; set; } = new();
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalPrice { get; set; }
    }
}
