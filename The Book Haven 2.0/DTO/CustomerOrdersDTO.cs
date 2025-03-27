using TheBookHaven2.Models;

namespace TheBookHaven2.DTO
{
    public class CustomerOrdersDTO
{
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Order> Orders { get; set; }
    }
}
