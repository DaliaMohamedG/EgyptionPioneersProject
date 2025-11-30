using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgyptionPioneersProject.Models
{
    public class Disease_Treatment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Dis_Id { get; set; }
        public Disease Disease { get; set; }

        public int T_Id { get; set; }
        public Treatment Treatment { get; set; }
    }
}
