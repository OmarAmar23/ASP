using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestASP.Models
{
    public class Item
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("The Price")]
        [Range(10,1000,ErrorMessage = "value of {0} must be between {1} and {2}.")]
        public decimal price { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Required]
        [DisplayName("Category")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public string? imagePath { get; set; }

        [NotMapped]
        public IFormFile clientFile { get; set; }

        public Category? Category { get; set; }



    }
}
