using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgyptionPioneersProject.Models
{
    public class Treatment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int T_Id { get; set; }
        public string T_Name { get; set; }
        public string T_Description { get; set; }
        public string T_Instruction { get; set; }
        public string T_Duration { get; set; }

        public ICollection<Disease_Treatment> DiseaseTreatments { get; set; }
        public ICollection<Treatment_Product> TreatmentProducts { get; set; }
    }
}
