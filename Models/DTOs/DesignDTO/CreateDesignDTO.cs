using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models.DTOs.DesignDTO
{
    public class CreateDesignDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Max char is 50")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Type is required")]
        [MaxLength(50, ErrorMessage = "Max char is 50")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Image is required")]
        [MaxLength(250, ErrorMessage = "Max char is 50")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Height is required")]
        public double Height { get; set; }

        [Required(ErrorMessage = "Width is required")]
        public double Width { get; set; }
        [Required(ErrorMessage = "Weight is required")]
        public double Weight { get; set; }
        [Required(ErrorMessage = "EstimatedPrice is required")]
        public double EstimatedPrice { get; set; }
    }
}
