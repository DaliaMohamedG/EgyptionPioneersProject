using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;

public class Order
{
    public int O_Id { get; set; }
    public DateTime O_Date { get; set; }
    public string O_Status { get; set; }

    [Precision(18, 2)]
    public decimal O_Total_Amount { get; set; }

    public int P_Id { get; set; }
    public Patient Patient { get; set; }

    public ICollection<Order_Product> OrderProducts { get; set; }
}
