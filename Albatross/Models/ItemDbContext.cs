using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Albatross.Models;
using System.Security.Cryptography.X509Certificates;

namespace Albatross.Models;
//namespace Albatross.Data;

//namespace Albatross.DAL;

public class ItemDbContext : DbContext
{
    public ItemDbContext(DbContextOptions<ItemDbContext> options) : base(options)
    {
        Database.EnsureCreated(); //remove (add // -) line if migrations is used
    }
    

    public DbSet<Item> Items { get; set; }
    public DbSet<Inventory> Inventories { get; set; } //*

    /*public DbSet<User> Users { get; set; }
    public DbSet<UserType> UserTypes { get; set; }*/

    public DbSet<Module> Modules { get; set; }
    public DbSet<ModuleTopic> ModuleTopics { get; set; }
    public DbSet<ATask> ATasks { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<AnswerOption> AnswerOptions { get; set; }

    //public DbSet<AnswerType> AnswerTypes { get; set; } 

    //Nulls
    public DbSet<NullModuleTopic> NullModuleTopics { get; set; }


    public DbSet<UserModel> UserModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    
}