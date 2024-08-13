using Microsoft.EntityFrameworkCore;

namespace CRUD.Models
{
    public class StoreContext :DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        { }

        public DbSet<PreWorkouts> PreWorkouts { get; set; }
        public DbSet<Brands> Brands { get; set; }
    }
}
