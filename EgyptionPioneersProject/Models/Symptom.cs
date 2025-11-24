namespace EgyptionPioneersProject.Models
{
    public class Symptom
    {
        public int S_Id { get; set; }
        public string S_Description { get; set; }

        public ICollection<Disease_Symptom> DiseaseSymptoms { get; set; }
    }
}
