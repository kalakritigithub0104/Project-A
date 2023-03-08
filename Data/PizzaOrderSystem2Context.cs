using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzaOrderSystem2.Models;

namespace PizzaOrderSystem2.Data
{
    public class PizzaOrderSystem2Context : IdentityDbContext
    {
        public PizzaOrderSystem2Context (DbContextOptions<PizzaOrderSystem2Context> options)
            : base(options)
        {
        }

        public DbSet<PizzaOrderSystem2.Models.Pizza> Pizza { get; set; } = default!;

        public DbSet<PizzaOrderSystem2.Models.Order> Order { get; set; } = default!;

        public DbSet<PizzaOrderSystem2.Models.Status> Status { get; set; } = default!;
    }
}
