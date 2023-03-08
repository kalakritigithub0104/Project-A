using System.ComponentModel.DataAnnotations;

namespace PizzaOrderSystem2.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaID { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Speciality { get; set; }
        public string? Crust { get; set; }
        public string? Size { get; set; }
        public double Price { get; set; }
        
    }
}
