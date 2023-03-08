using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PizzaOrderSystem2.Data;
using Microsoft.AspNetCore.Identity;
using PizzaOrderSystem2.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PizzaOrderSystem2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PizzaOrderSystem2Context") ?? throw new InvalidOperationException("Connection string 'PizzaOrderSystem2Context' not found.")));
builder.Services.AddDbContext<DataPizzaOrderSystem2Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataPizzaOrderSystem2ContextConnection")));
builder.Services.AddDefaultIdentity<PizzaOrderSystem2User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DataPizzaOrderSystem2Context>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();    
app.Run();
