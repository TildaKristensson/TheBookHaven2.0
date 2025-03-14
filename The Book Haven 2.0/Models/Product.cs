using System.ComponentModel.DataAnnotations;

namespace TheBookHaven2.Models
{
    public class Product
{
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }
        public string Category { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
