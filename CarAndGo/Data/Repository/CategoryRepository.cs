using CarAndGo.Data.Interfaces;
using CarAndGo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAndGo.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContent appDBContent;

        /* atgavimas duomenu is DB*/
        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Category> Categories => appDBContent.Category; /* atgauname visus kategorijas */
    }
}
