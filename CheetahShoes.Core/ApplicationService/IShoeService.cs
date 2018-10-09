using CheetahShoes.Core.Entities;
using System.Collections.Generic;

namespace CheetahShoes.Core.ApplicationService
{
    public interface IShoeService
    {
        List<Shoe> getAllShoes();
        Shoe Create(Shoe shoe);
        Shoe ReadById(int id);
        Shoe Update(Shoe shoeUpdate);
        void Delete(int id);
    }
}