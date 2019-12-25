using Dvor.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dvor.DAL.EF
{
    public class DvorContext : DbContext
    {
        public DvorContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<DishAllergy> DishAllergies { get; set; }

        public DbSet<Allergy> Allergies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishAllergy>()
                .HasKey(dishAllergy => new { dishAllergy.DishId, dishAllergy.AllergyId });

            modelBuilder.Entity<Category>().HasData(
            new Category{CategoryId = "firstDishes", Name = "First Dishes"},
            new Category{CategoryId = "secondDishes", Name = "Second Dishes"},
            new Category{CategoryId = "lunches", Name = "Lunches"},
            new Category{CategoryId = "Deserts", Name = "Deserts"},
            new Category{CategoryId = "Drinks", Name = "Drinks"},
            new Category{CategoryId = "Salads", Name = "Salads" }
            );
        }
    }
}