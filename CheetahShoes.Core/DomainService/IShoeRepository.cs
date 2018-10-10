using CheetahShoes.Core.Entities;
using System.Collections;
using System.Collections.Generic;

namespace CheetahShoes.Core.DomainService
{
    public interface IShoeRepository
    {
        IEnumerable<Shoe> ReadAllShoes(Filter filter);
        Shoe Create(Shoe shoe);
        Shoe ReadById(int id);
        Shoe Update(Shoe shoeUpdate);
        void Delete(int id);

    }
}