using CarAndGo.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAndGo.Data
{
    public class DBObjects
    {
        public static void Initial(IApplicationBuilder applicationBuilder)
        {/*AppDBContent content*/


            var scope = applicationBuilder.ApplicationServices.CreateScope();
            var content = scope.ServiceProvider.GetService<AppDBContent>();

            if (!content.Category.Any()) /* any-visi ... nera objektu */
            {
                content.Category.AddRange(Categories.Select(c => c.Value)); /*Linq, paimantis visus Value ir priadina jas */
            };

            if (!content.Car.Any()) /* any-visi ... nera objektu */{
                content.AddRange(

                     new Car
                     {
                         Name = "a",
                         Price = 7495,
                         ShortDescription = "fasfasfasas",
                         Category = Categories["Benzininis"],
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
                        Category = Categories["Benzininis"],
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
                        Category = Categories["Benzininis"],
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
                        Category = Categories["Benzininis"],
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
                        Category = Categories["Benzininis"],
                        ImageUrl = "/img/Benz.jpg",
                        InStock = true,
                        IsPreferredCar = true,
                        ImageThumbnaiUrl = "/img/Benz.jpg"
                    }

                );
            };

            content.SaveChanges(); 
        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
              if (category == null)
              {
                    var list = new Category[]
                    {
                        new Category {CategoryName = "Benzininis", Description ="Visi Benzininio-variklio automobiliai"},
                        new Category {CategoryName = "Elektromobiliai", Description ="Visi elektro-klases automobiliai"}
                    };
                
                category = new Dictionary<string, Category>(); /* atmintis  */
                foreach(Category el in list)
                {
                        category.Add(el.CategoryName, el);
                }
              }
                return category;
            }
        }

       
    }
}
