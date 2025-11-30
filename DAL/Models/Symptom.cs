using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgyptionPioneersProject.Models
{
    public class Symptom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int S_Id { get; set; }
        public string S_Description { get; set; }

        public ICollection<Disease_Symptom> DiseaseSymptoms { get; set; }
    }
}
