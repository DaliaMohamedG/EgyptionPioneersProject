namespace EgyptionPioneersProject.Models
{
    public class Patient
    {
        public int P_Id { get; set; }
        public string P_Name { get; set; }
        public string P_Email { get; set; }
        public string P_Pass { get; set; }
        public string P_Gender { get; set; }
        public int P_Age { get; set; }
        public string Skin_Type { get; set; }
        public string Medical_History { get; set; }

        // Navigation Properties
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<ChatbotSession> ChatbotSessions { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
}
