using CarAndGo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAndGo.Data.Interfaces
{
    public interface ICategoryRepository
    {
        /* hold all categories */
        IEnumerable<Category> Categories { get; }


    }
}
