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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Module>().HasData(
       new Module { ModuleId = 10, ModuleName = "A1", Description = "Basic Level", IsLocked = false },
       new Module { ModuleId = 20, ModuleName = "A2", Description = "Finish Level A1", IsLocked = true },
       new Module { ModuleId = 30, ModuleName = "B1", Description = "Finish Level A2", IsLocked = true }
   );

        modelBuilder.Entity<ModuleTopic>()
           .HasOne(mt => mt.Module) // ModuleTopic har en Module
           .WithMany(m => m.ModuleTopics) // En Module kan ha mange ModuleTopics
           .HasForeignKey(mt => mt.ModuleId); // Fremmednøkkelen i ModuleTopic peker på ModuleId
        

        modelBuilder.Entity<ModuleTopic>().HasData(
            new ModuleTopic { ModuleTopicId = 114, ModuleId = 10, ModuleTopicName = "Demo: Alphabet" },
            new ModuleTopic { ModuleTopicId = 115, ModuleId = 10, ModuleTopicName = "Demo: Numbers" }

    );
    }

    //public DbSet<AnswerType> AnswerTypes { get; set; } 


    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }*/

    //Nulls
    //public DbSet<NullModuleTopic> NullModuleTopics { get; set; }
}