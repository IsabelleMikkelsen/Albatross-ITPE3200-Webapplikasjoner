using Albatross.Models;
using Microsoft.EntityFrameworkCore;

namespace Albatross.Models;
//namespace Albatross.DAL;

public static class DBInit
{
    public static void Seed(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateAsyncScope();
        ItemDbContext context = serviceScope.ServiceProvider.GetRequiredService<ItemDbContext>();
        //context.Database.EnsureDeleted(); --- så db ikke slettes hver gang det kjøres
        context.Database.EnsureCreated();

        if (!context.Items.Any())
        {
            var items = new List<Item>();
            context.AddRange(items);
            context.SaveChanges();
        }
    }
}