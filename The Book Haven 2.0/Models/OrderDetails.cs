using System.Text.Json.Serialization;

namespace TheBookHaven2.Models
{
    public class OrderDetails
{
        public int Id { get; set; }
        public int OrderId { get; set; }

        [JsonIgnore]
        public Order Order { get; set; } = default!;
        public int ProductId { get; set; }

        [JsonIgnore]
        public Product Product { get; set; } = default!;
        public int Quantity { get; set; }
       
    }
}
