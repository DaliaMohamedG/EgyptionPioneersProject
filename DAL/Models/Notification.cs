using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgyptionPioneersProject.Models
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
