using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Albatross.Models;

namespace Albatross.Models;
//namespace Albatross.DAL;

public class ItemDbContext : IdentityDbContext<User>
{
    public ItemDbContext(DbContextOptions<ItemDbContext> options) : base(options)
    {
       // Database.EnsureCreated(); //Removed because migrations is used
    }

    public DbSet<Item> Items { get; set; }
    public DbSet<Inventory> Inventories { get; set; } //*

    public DbSet<Player> Players { get; set; }
    public DbSet<Admin> Admins { get; set; }

    public DbSet<Module> Modules { get; set; }
    public DbSet<ModuleTopic> ModuleTopics { get; set; }
    public DbSet<ATask> ATasks { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<AnswerOption> AnswerOptions { get; set; }
    //public DbSet<AnswerType> AnswerTypes { get; set; } 


    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }*/

    //Nulls
    public DbSet<NullModuleTopic> NullModuleTopics { get; set; }
}