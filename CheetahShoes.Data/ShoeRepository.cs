using CheetahShoes.Core.DomainService;
using CheetahShoes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace CheetahShoes.Data
{
    public class ShoeRepository : IShoeRepository
    {
        public readonly CShoesContext _ctx;
        public ShoeRepository(CShoesContext ctx)
        {
            _ctx = ctx;
        }
        public Shoe Create(Shoe shoe)
        {
            _ctx.Attach(shoe).State = EntityState.Added;
            _ctx.SaveChanges();
            return shoe;
        }

        public void Delete(int id)
        {
            if (!_ctx.Shoes.Any(x => x.Id == id))
            {
                throw new SqlNullValueException($"No shoe with id {id} was found.");
            }

            _ctx.Shoes.Remove(_ctx.Shoes.First(x => x.Id == id));
            _ctx.SaveChanges();
        }

        public IEnumerable<Shoe> ReadAllShoes(Filter filter)
        {
            if(filter == null)
                return _ctx.Shoes
                        .Include(x => x.Sizes)
                        .ThenInclude(x => x.Size);
            else
            {
                return _ctx.Shoes
                        .Skip((filter.CurrentPage - 1) * filter.ItemsPerPage)
                        .Take(filter.ItemsPerPage);
            }
        }

        public Shoe ReadById(int id)
        {
            Shoe shoe = _ctx.Shoes
                .Include(x => x.Sizes)
                .ThenInclude(x => x.Size)
                .FirstOrDefault(x => x.Id == id);
            if(shoe == null) throw new ArgumentException($"No shoe found ID: {id}");
            return shoe;
        }

        public Shoe Update(Shoe shoeUpdate)
        {
            if(!_ctx.Shoes.Any(x => x.Id == shoeUpdate.Id)) throw new ArgumentException($"Could not find shoe with id {shoeUpdate.Id}.");
            try
            {
                _ctx.Attach(shoeUpdate).State = EntityState.Modified;
                _ctx.ShoeSizes.RemoveRange(_ctx.ShoeSizes.Where(x => x.ShoeId == shoeUpdate.Id));
                _ctx.Entry(shoeUpdate).Collection(su => su.Sizes).IsModified = true;
                _ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
            //if (!_ctx.Pets.Any(x => x.Id == id)) throw new ArgumentException($"Could not find any pet with ID {id}!");
            //try
            //{
            //    _ctx.Attach(newPet).State = EntityState.Modified;
            //    _ctx.Entry(newPet).Reference(x => x.Owner).IsModified = true;
            //    _ctx.Entry(newPet).Collection(np => np.Colors).IsModified = true;
            //    _ctx.SaveChanges();
            //}
            //catch (Exception e)
            //{
            //    throw new Exception("Failed to save pet!");
            //}
            //return newPet;

            return shoeUpdate;
        }

    }
}
