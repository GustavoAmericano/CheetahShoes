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

            var size1 = ctx.Sizes.Add(new Size()
            {
                Id = 1,
                SizeNumber = 44,
            }).Entity;
            var size2 = ctx.Sizes.Add(new Size()
            {
                Id = 2,
                SizeNumber = 45,
            }).Entity;

            var size3 = ctx.Sizes.Add(new Size()
            {
                Id = 3,
                SizeNumber = 1337,
            }).Entity;

            var shoe1 = ctx.Shoes.Add(new Shoe
            {
                Id = 1,
                Brand = "Nike",
                Model = "Airmax",
                Description = "Flot",
                Gender = "Male",
                Picture = "url",
                Price = 500,
            }).Entity;

            var shoeSize1 = ctx.ShoeSizes.Add(new ShoeSize()
            {
                Size = size1,
                SizeId = size1.Id,

                Shoe = shoe1,
                ShoeId = shoe1.Id,
                Stock = 5,
            });
            var shoeSize2 = ctx.ShoeSizes.Add(new ShoeSize()
            {
                Size = size2,
                SizeId = size2.Id,

                Shoe = shoe1,
                ShoeId = shoe1.Id,
                Stock = 129382181
            });

            ctx.SaveChanges();
        }
    }
}