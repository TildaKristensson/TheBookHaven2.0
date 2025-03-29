namespace TheBookHaven2.DTO
{
    public class OrderDTO
{
        public int OrderId { get; set; }
        public List<ProductDTO> Products { get; set; } = new();
}
}
