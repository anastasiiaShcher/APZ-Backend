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
    }
}