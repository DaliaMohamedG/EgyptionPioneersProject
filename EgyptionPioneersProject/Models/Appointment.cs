namespace EgyptionPioneersProject.Models
{
    public class Appointment
    {
        public int Ap_Id { get; set; }
        public DateTime A_Date { get; set; }
        public TimeSpan A_Time { get; set; }
        public string A_Status { get; set; }

        // Foreign Keys
        public int P_Id { get; set; }
        public int D_Id { get; set; }

        // Navigation
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
