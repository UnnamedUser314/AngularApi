using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models.Entity
{
    public class DesignEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        [Required]
        [MaxLength(250)]
        public string Image { get; set; }


        [Required]
        public int Year { get; set; }
        [Required]
        public double Height { get; set; }

        [Required]
        public double Width { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public double EstimatedPrice { get; set; }
    }
}
