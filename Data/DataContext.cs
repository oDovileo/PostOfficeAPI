using Microsoft.EntityFrameworkCore;
using PostOfficeAPI.Entities;

namespace PostOfficeAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<ParcelModel> Parcels { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostModel>()
                .HasMany(pl => pl.Parcels)
                .WithOne()
                .HasForeignKey(p => p.PostId);
        }
    }
}
