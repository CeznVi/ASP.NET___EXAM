using Microsoft.EntityFrameworkCore;

namespace FlowerMarket.Models
{
    public class DBase: DbContext
    {
        public DbSet<FlowerModel> data { get; set; } = null!;

        public DBase(DbContextOptions<DBase> options)
            : base(options) 
        { 
            Database.EnsureCreated();
        }

    }
}
