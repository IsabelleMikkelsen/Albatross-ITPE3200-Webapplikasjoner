using Microsoft.EntityFrameworkCore;
using Albatross.Models;

namespace Albatross.Models;

public class ItemDbContext : DbContext
{
    public ItemDbContext(DbContextOptions<ItemDbContext> options) : base(options)
    {
        Database.EnsureCreated(); //remove (add // -) line if migrations is used
    }

    public DbSet<Item> Items { get; set; }
    public DbSet<Inventory> Inventories { get; set; } //*

    public DbSet<User> Users { get; set; } 
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
}