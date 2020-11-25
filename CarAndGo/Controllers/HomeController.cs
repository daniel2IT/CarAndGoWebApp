using CarAndGo.Data.Interfaces;
using CarAndGo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAndGo.Controllers
{
    public class HomeController : Controller
    {

        private ICarRepository _carRep;

        public HomeController(ICarRepository carRep)
        {
            _carRep = carRep;
        }

        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                favCars = _carRep.PreferredCars
            };
            return View(homeCars); /* Objektai kurie bus atvaizduojami General Page */
        }

    }
}
