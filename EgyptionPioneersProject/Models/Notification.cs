namespace EgyptionPioneersProject.Models
{
    public class Notification
    {
        public int N_Id { get; set; }
        public string N_Type { get; set; }
        public DateTime N_Date { get; set; }
        public string N_Message { get; set; }

        // Foreign Keys
        public int? P_Id { get; set; }
        public int? D_Id { get; set; }

        // Navigation
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
