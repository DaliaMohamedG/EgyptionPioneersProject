namespace EgyptionPioneersProject.Models
{
    public class Disease_Symptom
    {
        public int Dis_Id { get; set; }
        public Disease Disease { get; set; }

        public int S_Id { get; set; }
        public Symptom Symptom { get; set; }
    }
}
