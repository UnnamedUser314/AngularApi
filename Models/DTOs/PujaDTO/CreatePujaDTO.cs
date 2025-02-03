using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models.DTOs.PujaDTO
{
    public class CreatePujaDTO
    {
        [Required(ErrorMessage = "FirstName is required")]
        [MaxLength(50, ErrorMessage = "Max char is 50")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        [MaxLength(50, ErrorMessage = "Max char is 50")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(250, ErrorMessage = "Max char is 50")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public int Amount { get; set; }
    }
}
