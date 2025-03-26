namespace TheBookHaven2.DTO
{
    public class CreateOrderDTO
{
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<OrderDetailsDTO> OrderDetails { get; set; } = new();
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalPrice { get; set; }
    }
}
