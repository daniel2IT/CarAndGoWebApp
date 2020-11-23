using CarAndGo.Data.Interfaces;
using CarAndGo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAndGo.Data.mocks
{
    public class MockCarRepository : ICarRepository
    {

        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Car> Car{
            get
            {
                return new List<Car>
                {
                    new Car
                    {
                        Name = "a",
                        Price = 7495,
                        ShortDescription = "fasfasfasas",
                        Category = _categoryRepository.Categories.First(),
                        ImageUrl = "/img/Benz.jpg",
                        InStock = true,
                        IsPreferredCar = true,
                        ImageThumbnaiUrl = "/img/Benz.jpg"
                    },
                    new Car
                    {
                        Name = "a",
                        Price = 7495,
                        ShortDescription = "fasfasfasas",
                        Category = _categoryRepository.Categories.First(),
                        ImageUrl = "/img/Benz.jpg",
                        InStock = true,
                        IsPreferredCar = true,
                        ImageThumbnaiUrl = "/img/Benz.jpg"
                    },
                    new Car
                    {
                        Name = "a",
                        Price = 7495,
                        ShortDescription = "fasfasfasas",
                        Category = _categoryRepository.Categories.First(),
                        ImageUrl = "/img/Benz.jpg",
                        InStock = true,
                        IsPreferredCar = true,
                        ImageThumbnaiUrl = "/img/Benz.jpg"
                    },
                    new Car
                    {
                        Name = "a",
                        Price = 7495,
                        ShortDescription = "fasfasfasas",
                        Category = _categoryRepository.Categories.First(),
                        ImageUrl = "/img/Benz.jpg",
                        InStock = true,
                        IsPreferredCar = true,
                        ImageThumbnaiUrl = "/img/Benz.jpg"
                    },
                    new Car
                    {
                        Name = "a",
                        Price = 7495,
                        ShortDescription = "fasfasfasas",
                        Category = _categoryRepository.Categories.First(),
                        ImageUrl = "/img/Benz.jpg",
                        InStock = true,
                        IsPreferredCar = true,
                        ImageThumbnaiUrl = "/img/Benz.jpg"
                    }
                };
            } 
        }
        public IEnumerable<Car> PreferredCars { get; }

        public Car getCarById(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
