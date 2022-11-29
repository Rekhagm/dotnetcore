using System.ComponentModel.DataAnnotations;
namespace ecommapp.Models
{
    public class products
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public string? Category { get; set; }

        [Required]
        public int? stock { get; set; }

        [Required]
        public string? brand { get; set; }

        [Required]
        public double? Price { get; set; } 
    }
}
