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
    public DbSet<NewQuiz> NewQuizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<AnswerOption> AnswerOptions { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Module>().HasData(
       new Module { ModuleId = 8, ModuleName = "Your Quizzes" },
       new Module { ModuleId = 9, ModuleName = "Browse Quizzes" }
   );

        modelBuilder.Entity<ModuleTopic>()
           .HasOne(mt => mt.Module) // ModuleTopic har en Module
           .WithMany(m => m.ModuleTopics) // En Module kan ha mange ModuleTopics
           .HasForeignKey(mt => mt.ModuleId); // Fremmednøkkelen i ModuleTopic peker på ModuleId
        

        modelBuilder.Entity<ModuleTopic>().HasData(
            new ModuleTopic { ModuleTopicId = 118, ModuleId = 8, ModuleTopicName = "Demo: Words and phrases" },
            new ModuleTopic { ModuleTopicId = 119, ModuleId = 8, ModuleTopicName = "Demo: Nature" }

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