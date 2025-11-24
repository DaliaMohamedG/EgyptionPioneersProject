namespace EgyptionPioneersProject.Models
{
    public class Order_Product
    {
        public int O_Id { get; set; }
        public Order Order { get; set; }

        public int Pr_Id { get; set; }
        public Product Product { get; set; }
    }
}
