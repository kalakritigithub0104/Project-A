using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PizzaOrderSystem2.Models
{
    public class Status
    {
        [Key]
        public int StatusID { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public Order? Order { get; set; }
        public string? OrderStatus { get; set; }
    }
}
