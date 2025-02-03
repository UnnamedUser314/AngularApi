using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models.Entity
{
    public class PujaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }


        public DateTime CreatedDate { get; set; }


        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }


        [Required]
        [MaxLength(50)]
        public string Email { get; set; }


        [Required]
        public double Amount { get; set; }
    }
}
