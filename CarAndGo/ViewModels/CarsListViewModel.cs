using CarAndGo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAndGo.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public string CurrentCategory { get; set; }
    }
}
