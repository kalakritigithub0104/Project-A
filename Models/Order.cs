using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaOrderSystem2.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public string? AddedFlavors { get; set; }
        public double Contact_No { get; set; }
        public string? Address { get; set; }
        public double Total { get; set; }
        [ForeignKey("Pizza")]
        public int PizzaID { get; set; }
        public Pizza? Pizza { get; set; }
        }
}
