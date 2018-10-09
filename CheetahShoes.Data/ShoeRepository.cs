using CheetahShoes.Core.DomainService;
using CheetahShoes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            if (!_ctx.Shoes.Any(x => x.Id == id))
            {
                throw new SqlNullValueException($"No shoe with id {id} was found.");
            }

            //_ctx.Sizes.RemoveRange(_ctx.);
            _ctx.Shoes.Remove(_ctx.Shoes.First(x => x.Id == id));
            _ctx.SaveChanges();
        }

        public IEnumerable<Shoe> ReadAllShoes()
        {
            return _ctx.Shoes;
        }

        public Shoe ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Shoe Update(Shoe shoeUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
