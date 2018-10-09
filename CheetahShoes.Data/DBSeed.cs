using System;
using System.Collections.Generic;
using CheetahShoes.Core.Entities;

namespace CheetahShoes.Data
{
    public class DBSeed
    {
        public static void SeedDB(CShoesContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            //var size1 = ctx.Sizes.Add(new Size()
            //{
            //    Id = 1,
            //    SizeNumber = 44,
            //    Quantity = 12
            //}).Entity;
            //var size2 = ctx.Sizes.Add(new Size()
            //{
            //    Id = 2,
            //    SizeNumber = 45,
            //    Quantity = 8
            //}).Entity;
            var size1 = new Size()
            {
                Id = 1,
                SizeNumber = 44,
                Quantity = 12
            };
            var size2 = new Size()
            {
                Id = 2,
                SizeNumber = 44,
                Quantity = 12
            };

            var shoe1 = ctx.Shoes.Add(new Shoe
            {
                Id = 1,
                //Brand = "Nike",
                Model = "Airmax",
                Description = "Flot",
                Gender = "Male",
                Picture = "url",
                Price = 500,
                Sizes = new List<Size>() {size1,size2}
            }).Entity;

            ctx.SaveChanges();
        }
    }
}