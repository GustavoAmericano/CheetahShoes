using System;
using System.Collections.Generic;
using System.Linq;
using CheetahShoes.Core.ApplicationService;
using CheetahShoes.Core.DomainService;
using CheetahShoes.Core.Entities;

namespace CheetahShoes.Core
{
    public class ShoeService : IShoeService
    {
        private readonly IShoeRepository _shoeRepo;

        public ShoeService(IShoeRepository repo)
        {

            _shoeRepo = repo;

        }
        public Shoe Create(Shoe shoe)
        {
            try
            {
                ValidateData(shoe);
            }
            catch (Exception e)
            {
               
                throw;
            }
            return _shoeRepo.Create(shoe);
           
        }

        public void Delete(int id)
        {
            _shoeRepo.Delete(id);
        }

        public List<Shoe> getAllShoes(Filter filter)
        {
            return _shoeRepo.ReadAllShoes(filter).ToList();
        }

        public Shoe ReadById(int id)
        {
            return _shoeRepo.ReadById(id);
        }

        public Shoe Update(Shoe shoeUpdate)
        {
            try
            {
                ValidateData(shoeUpdate);
            }
            catch (Exception e)
            {
                throw;
            }
            return _shoeRepo.Update(shoeUpdate);
        }

        public void ValidateData(Shoe shoe)
        {
            if (shoe.Price <= 0)
            {
                throw new ArgumentException("Price cannot be null");
            }

            else if (string.IsNullOrEmpty(shoe.Model))
            {
                throw new ArgumentException("Shoe must have a model");
            }
            else if (string.IsNullOrEmpty(shoe.Brand))
            {
                throw new ArgumentException("Shoe must have a brand");
            }
            else if (string.IsNullOrEmpty(shoe.Description))
            {
                throw new ArgumentException("Shoe needs a description");
            }


        }
    }
}
