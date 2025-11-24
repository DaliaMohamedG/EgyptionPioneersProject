namespace EgyptionPioneersProject.Models
{
    public class Doctor
    {
        public int D_Id { get; set; }
        public string D_Name { get; set; }
        public string D_Email { get; set; }
        public string D_Pass { get; set; }
        public string D_Specialization { get; set; }
        public string D_Experience { get; set; }
        public string D_Working_Hour { get; set; }

        // Navigation Properties
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
}
