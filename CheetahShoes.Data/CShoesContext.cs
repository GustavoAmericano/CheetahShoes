using CheetahShoes.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CheetahShoes.Data
{
    public class CShoesContext : DbContext
    {
        public CShoesContext(DbContextOptions<CShoesContext> dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoeSize>()
                .HasKey(ss => new {ss.ShoeId, ss.SizeId});

            modelBuilder.Entity<ShoeSize>()
                .HasOne<Shoe>(ss => ss.Shoe)
                .WithMany(shoe => shoe.Sizes)
                .HasForeignKey(ss => ss.ShoeId);


            modelBuilder.Entity<ShoeSize>()
                .HasOne<Size>(ss => ss.Size)
                .WithMany(size => size.Shoes)
                .HasForeignKey(ss => ss.SizeId);

        }

        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ShoeSize> ShoeSizes { get; set; }
    }
}