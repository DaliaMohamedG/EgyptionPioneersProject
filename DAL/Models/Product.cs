using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EgyptionPioneersProject.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Pr_Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Pr_Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Pr_Description { get; set; }

        [Precision(18, 2)]
        [Required(ErrorMessage = "Price is required")]
        public decimal Pr_Price { get; set; }

        [Required(ErrorMessage = "Stock is required")]
        public int Pr_Stock { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Pr_Category { get; set; }

        public string? Pr_Image { get; set; }

        public ICollection<Treatment_Product> TreatmentProducts { get; set; }
        public ICollection<Order_Product> OrderProducts { get; set; }
    }
}