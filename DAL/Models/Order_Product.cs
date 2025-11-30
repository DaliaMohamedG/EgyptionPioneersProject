using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgyptionPioneersProject.Models
{
    public class Order_Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int O_Id { get; set; }
        public Order Order { get; set; }

        public int Pr_Id { get; set; }
        public Product Product { get; set; }
    }
}
