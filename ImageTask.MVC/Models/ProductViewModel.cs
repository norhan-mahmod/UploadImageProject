using System.ComponentModel.DataAnnotations;

namespace ImageTask.MVC.Models
{
    public class ProductViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        public string? ImageSource { get; set; }
    }
}
