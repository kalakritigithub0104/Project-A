using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzaOrderSystem2.Areas.Identity.Data;

namespace PizzaOrderSystem2.Areas.Identity.Data;

public class DataPizzaOrderSystem2Context : IdentityDbContext<PizzaOrderSystem2User>
{
    public DataPizzaOrderSystem2Context(DbContextOptions<DataPizzaOrderSystem2Context> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
