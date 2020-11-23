using CarAndGo.Data.Interfaces;
using CarAndGo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAndGo.Data.mocks
{  /* Mockers are just simple C# classes which have methods to return data using the models */
    public class MockCategoryRepository: ICategoryRepository
    {

        public IEnumerable<Category> Categories {
            get
            {
                return new List<Category>
                {
                new Category {CategoryName = "Benzininis", Description ="Visi Benzininio-variklio automobiliai"},
                new Category {CategoryName = "Elektromobiliai", Description ="Visi elektro-klases automobiliai"}
                };
            } 
        }

    }
}
