using Albatross.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Albatross.Models;
//namespace Albatross.DAL;

public static class DBInit
{
    //public static void Seed(IApplicationBuilder app)
    public static async void Seed(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateAsyncScope();
        //ItemDbContext context = serviceScope.ServiceProvider.GetRequiredService<ItemDbContext>();
        var context = serviceScope.ServiceProvider.GetRequiredService<ItemDbContext>();
        //context.Database.EnsureDeleted(); --- så db ikke slettes hver gang det kjøres

        //Get services for creating users and roles
        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //Create roles
        if (!await roleManager.RoleExistsAsync("Admin")) await roleManager.CreateAsync(new IdentityRole("Admin"));
        if (!await roleManager.RoleExistsAsync("Player")) await roleManager.CreateAsync(new IdentityRole("Player"));

        //Create admin-user
        var adminUser = await userManager.FindByEmailAsync("admin@albatross.com");
        if (adminUser == null)
        {
            adminUser = new User
            {
                UserName = "admin",
                Email = "admin@albatross.com",
                FirstName = "Admin",
                LastName = "User"
            };
            await userManager.CreateAsync(adminUser, "Admin123!");
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
        //Remove to avoid bypassing Migrations?
        //context.Database.EnsureCreated();

        //Only keep context.SaveChanges(); ? Avoids empty entries
        if (!context.Items.Any())
        {
            //var items = new List<Item>();
            //context.AddRange(items);
            context.SaveChanges();
        }
    }
}