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
                        ImageUrl = "https://www.polizinginiai.lt/image.php?i=L2hvbWUvZ3RhdXRvY2FyLmx0L3B1YmxpY19odG1sL2F1dG9pbWcvMjAyMDA0L1RveW90YS1BdXJpcy0zMTE2MzkwNTEtMS00MDAuanBn",
                        InStock = true,
                        IsPreferredCar = true,
                        ImageThumbnaiUrl = "dasdasda"
                    },
                    new Car
                    {
                        Name = "a",
                        Price = 7495,
                        ShortDescription = "fasfasfasas",
                        Category = _categoryRepository.Categories.First(),
                        ImageUrl = "https://www.polizinginiai.lt/image.php?i=L2hvbWUvZ3RhdXRvY2FyLmx0L3B1YmxpY19odG1sL2F1dG9pbWcvMjAyMDA0L1RveW90YS1BdXJpcy0zMTE2MzkwNTEtMS00MDAuanBn",
                        InStock = true,
                        IsPreferredCar = true,
                        ImageThumbnaiUrl = "dasdasda"
                    },
                    new Car
                    {
                        Name = "a",
                        Price = 7495,
                        ShortDescription = "fasfasfasas",
                        Category = _categoryRepository.Categories.First(),
                        ImageUrl = "https://www.polizinginiai.lt/image.php?i=L2hvbWUvZ3RhdXRvY2FyLmx0L3B1YmxpY19odG1sL2F1dG9pbWcvMjAyMDA0L1RveW90YS1BdXJpcy0zMTE2MzkwNTEtMS00MDAuanBn",
                        InStock = true,
                        IsPreferredCar = true,
                        ImageThumbnaiUrl = "dasdasda"
                    },
                    new Car
                    {
                        Name = "a",
                        Price = 7495,
                        ShortDescription = "fasfasfasas",
                        Category = _categoryRepository.Categories.First(),
                        ImageUrl = "https://www.polizinginiai.lt/image.php?i=L2hvbWUvZ3RhdXRvY2FyLmx0L3B1YmxpY19odG1sL2F1dG9pbWcvMjAyMDA0L1RveW90YS1BdXJpcy0zMTE2MzkwNTEtMS00MDAuanBn",
                        InStock = true,
                        IsPreferredCar = true,
                        ImageThumbnaiUrl = "dasdasda"
                    },
                    new Car
                    {
                        Name = "a",
                        Price = 7495,
                        ShortDescription = "fasfasfasas",
                        Category = _categoryRepository.Categories.First(),
                        ImageUrl = "https://www.polizinginiai.lt/image.php?i=L2hvbWUvZ3RhdXRvY2FyLmx0L3B1YmxpY19odG1sL2F1dG9pbWcvMjAyMDA0L1RveW90YS1BdXJpcy0zMTE2MzkwNTEtMS00MDAuanBn",
                        InStock = true,
                        IsPreferredCar = true,
                        ImageThumbnaiUrl = "dasdasda"
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
