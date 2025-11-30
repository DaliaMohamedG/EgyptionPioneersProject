using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgyptionPioneersProject.Models
{
    public class Disease_Symptom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Dis_Id { get; set; }
        public Disease Disease { get; set; }

        public int S_Id { get; set; }
        public Symptom Symptom { get; set; }
    }
}
