namespace EgyptionPioneersProject.Models
{
    public class Disease
    {
        public int Dis_Id { get; set; }
        public string Dis_Name { get; set; }
        public string Dis_Description { get; set; }
        public string Dis_Severity_Level { get; set; }

        public ICollection<Disease_Symptom> DiseaseSymptoms { get; set; }
        public ICollection<Disease_Treatment> DiseaseTreatments { get; set; }
        public ICollection<ChatbotSession> ChatbotSessions { get; set; }
        public ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
}
