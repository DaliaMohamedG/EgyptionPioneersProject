using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgyptionPioneersProject.Models
{
    public class ChatbotSession
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cs_Id { get; set; }
        public DateTime Cs_Date { get; set; }
        public string Cs_Result { get; set; }

        // Foreign Keys
        public int P_Id { get; set; }
        public int Dis_Id { get; set; }

        // Navigation
        public Patient Patient { get; set; }
        public Disease Disease { get; set; }
    }
}
