namespace EgyptionPioneersProject.Models
{
    public class MedicalRecord
    {
        public int Md_Id { get; set; }
        public string Md_Notes { get; set; }
        public string Md_Source { get; set; }
        public string Md_Diagnoses { get; set; }

        // Foreign Keys
        public int P_Id { get; set; }
        public int D_Id { get; set; }
        public int Dis_Id { get; set; }

        // Navigation
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public Disease Disease { get; set; }
    }
}
