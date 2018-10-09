using System;
using System.Collections.Generic;
using CheetahShoes.Core;
using CheetahShoes.Core.ApplicationService;
using CheetahShoes.Core.DomainService;
using CheetahShoes.Core.Entities;
using Moq;
using Xunit;

namespace ShoeServiceTest
{
    public class ShoeServiceTest
    {
        [Fact]
        public void CreateShoeNoPriceExpectException()
        {
            var shoeRepo = new Mock<IShoeRepository>();
            IShoeService service = new ShoeService(shoeRepo.Object);
            Shoe shoe = new Shoe()
            {
                Id = 1,
                Brand = "Nike",
                Model = "Airmax",
                Description = "Flot",
                Gender = "Male",
                Picture = "url",
                //Price = 500,
                Sizes = new List<Size>() { new Size() }
            };
            Exception e = Assert.Throws<ArgumentException>(() => service.Create(shoe));
            Assert.Equal("Price cannot be null", e.Message);
        }

        [Fact]
        public void CreateShoeTestShouldCallShoeRepoCreateOnce()
        {
            var shoeRepo = new Mock<IShoeRepository>();
            IShoeService service = new ShoeService(shoeRepo.Object);
            Shoe shoe = new Shoe()
            {
                Id = 1,
                Brand = "Nike",
                Model = "Airmax",
                Description = "Flot",
                Gender = "Male",
                Picture = "url",
                Price = 500,
                Sizes = new List<Size>() { new Size() }
            };
            service.Create(shoe);
            shoeRepo.Verify(x=>x.Create(It.IsAny<Shoe>()),Times.Once);
        }
        [Fact]
        public void CreateShoeNoBrandExpectException()
        {
            var shoeRepo = new Mock<IShoeRepository>();
            IShoeService service = new ShoeService(shoeRepo.Object);
            Shoe shoe = new Shoe()
            {
                Id = 1,
                //Brand = "Nike",
                Model = "Airmax",
                Description = "Flot",
                Gender = "Male",
                Picture = "url",
                Price = 500,
                Sizes = new List<Size>() { new Size() }
            };
            Exception e = Assert.Throws<ArgumentException>(() => service.Create(shoe));
            Assert.Equal("Shoe must have a brand", e.Message);
        }

        [Fact]
        public void CreateShoeNoModelExpectException()
        {
            var shoeRepo = new Mock<IShoeRepository>();
            IShoeService service = new ShoeService(shoeRepo.Object);
            Shoe shoe = new Shoe()
            {
                Id = 1,
                Brand = "Nike",
                //Model = "Airmax",
                Description = "Flot",
                Gender = "Male",
                Picture = "url",
                Price = 500,
                Sizes = new List<Size>() { new Size() }
            };
            Exception e = Assert.Throws<ArgumentException>(() => service.Create(shoe));
            Assert.Equal("Shoe must have a model", e.Message);
        }
        [Fact]
        public void CreateShoeNoDescriptionExpectException()
        {
            var shoeRepo = new Mock<IShoeRepository>();
            IShoeService service = new ShoeService(shoeRepo.Object);
            Shoe shoe = new Shoe()
            {
                Id = 1,
                Brand = "Nike",
                Model = "Airmax",
                //Description = "Flot",
                Gender = "Male",
                Picture = "url",
                Price = 500,
                Sizes = new List<Size>() { new Size() }
            };
            Exception e = Assert.Throws<ArgumentException>(() => service.Create(shoe));
            Assert.Equal("Shoe needs a description", e.Message);
        }

        [Fact]
        public void UpdateShoeNoPriceExpectException()
        {
            var shoeRepo = new Mock<IShoeRepository>();
            IShoeService service = new ShoeService(shoeRepo.Object);
            Shoe shoe = new Shoe()
            {
                Id = 1,
                Brand = "Nike",
                Model = "Airmax",
                Description = "Flot",
                Gender = "Male",
                Picture = "url",
                //Price = 500,
                Sizes = new List<Size>() { new Size() }
            };
            Exception e = Assert.Throws<ArgumentException>(() => service.Update(shoe));
            Assert.Equal("Price cannot be null", e.Message);
        }

        [Fact]
        public void UpdateShoeTestShouldCallShoeRepoCreateOnce()
        {
            var shoeRepo = new Mock<IShoeRepository>();
            IShoeService service = new ShoeService(shoeRepo.Object);
            Shoe shoe = new Shoe()
            {
                Id = 1,
                Brand = "Nike",
                Model = "Airmax",
                Description = "Flot",
                Gender = "Male",
                Picture = "url",
                Price = 500,
                Sizes = new List<Size>() { new Size() }
            };
            service.Update(shoe);
            shoeRepo.Verify(x => x.Update(It.IsAny<Shoe>()), Times.Once);
        }
        [Fact]
        public void UpdateShoeNoBrandExpectException()
        {
            var shoeRepo = new Mock<IShoeRepository>();
            IShoeService service = new ShoeService(shoeRepo.Object);
            Shoe shoe = new Shoe()
            {
                Id = 1,
                //Brand = "Nike",
                Model = "Airmax",
                Description = "Flot",
                Gender = "Male",
                Picture = "url",
                Price = 500,
                Sizes = new List<Size>() { new Size() }
            };
            Exception e = Assert.Throws<ArgumentException>(() => service.Update(shoe));
            Assert.Equal("Shoe must have a brand", e.Message);
        }

        [Fact]
        public void UpdateShoeNoModelExpectException()
        {
            var shoeRepo = new Mock<IShoeRepository>();
            IShoeService service = new ShoeService(shoeRepo.Object);
            Shoe shoe = new Shoe()
            {
                Id = 1,
                Brand = "Nike",
                //Model = "Airmax",
                Description = "Flot",
                Gender = "Male",
                Picture = "url",
                Price = 500,
                Sizes = new List<Size>() { new Size() }
            };
            Exception e = Assert.Throws<ArgumentException>(() => service.Update(shoe));
            Assert.Equal("Shoe must have a model", e.Message);
        }
        [Fact]
        public void UpdateShoeNoDescriptionExpectException()
        {
            var shoeRepo = new Mock<IShoeRepository>();
            IShoeService service = new ShoeService(shoeRepo.Object);
            Shoe shoe = new Shoe()
            {
                Id = 1,
                Brand = "Nike",
                Model = "Airmax",
                //Description = "Flot",
                Gender = "Male",
                Picture = "url",
                Price = 500,
                Sizes = new List<Size>() { new Size() }
            };
            Exception e = Assert.Throws<ArgumentException>(() => service.Update(shoe));
            Assert.Equal("Shoe needs a description", e.Message);
        }


    }
}
