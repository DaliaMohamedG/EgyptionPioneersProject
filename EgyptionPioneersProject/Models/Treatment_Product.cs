namespace EgyptionPioneersProject.Models
{
    public class Treatment_Product
    {
        public int T_Id { get; set; }
        public Treatment Treatment { get; set; }

        public int Pr_Id { get; set; }
        public Product Product { get; set; }
    }
}
