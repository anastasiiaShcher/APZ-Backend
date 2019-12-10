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
    }
}