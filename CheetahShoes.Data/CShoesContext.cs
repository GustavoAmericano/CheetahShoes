using CheetahShoes.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CheetahShoes.Data
{
    public class CShoesContext : DbContext
    {
        public CShoesContext(DbContextOptions<CShoesContext> dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Shoe>()
            //    .hasStuff
        }
    }
}