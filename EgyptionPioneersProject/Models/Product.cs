using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;

public class Product
{
    public int Pr_Id { get; set; }
    public string Pr_Name { get; set; }
    public string Pr_Description { get; set; }

    [Precision(18, 2)]
    public decimal Pr_Price { get; set; }

    public int Pr_Stock { get; set; }
    public string Pr_Category { get; set; }

    public ICollection<Treatment_Product> TreatmentProducts { get; set; }
    public ICollection<Order_Product> OrderProducts { get; set; }
}
