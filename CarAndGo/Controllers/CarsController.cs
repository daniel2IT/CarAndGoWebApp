using CarAndGo.Data.Interfaces;
using CarAndGo.Data.Models;
using CarAndGo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAndGo.Controllers
{
    /* Cia bus ivairuos funkcijos, iskvieciant jas bus grazinamas ViewResult(rezultatas Html pusl) tipas */
    /* deka 2 interfeisam, mes gausime visu duomenys esancius */
    public class CarsController : Controller
    {
       private readonly ICategoryRepository _categoryRepository; /* readonly - tik skaitymui */
       private readonly ICarRepository _carRepository;
       public CarsController(ICategoryRepository categoryRepository, ICarRepository carRepository)
       {
            /* Iskvieciant interfeisa mes kartu iskvieciame klase, kuris ji realizuoja, kodel? nes mes tai aprasem StartUp 
             * AddTransient<ICarRepository, MockCarRepository> tas metodas, butent suriso mum ta interfeisa su klase
             * logiskai, kad dabar perduodant interfeisa, bet kur, mes su jo gausime klase prirista per AddTransient*/
           _categoryRepository = categoryRepository;
           _carRepository = carRepository;
              /* is principo mes cia perdavem visus objektus aprasytus Mockse */
       }
        /* ViewResult - Metodas iskvieciantis visa HTML puslapi */
        /* List() - galejo buti uzvadinta bet kaip , funkcija iskviecianti visa sarasa */
        /* return View() - tiesiog grinas puslapis su HTML be jokiu papildomu funkciju , bet aprasem su atgaunama apacioj >>>> */
       [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
       {
            string _category = category;

            IEnumerable<Car> cars = null;
            string currCategory = "";

            if(string.IsNullOrEmpty(category))
            {
                cars = _carRepository.Car.OrderBy(i => i.CarId); /* Sortinam pagal ID */
            }
            else
            {
                if(string.Equals("encog", category,StringComparison.OrdinalIgnoreCase)) /* StringComparison.OrdinalIgnoreCase ignoroja tame zodije space, bruksniukus (registrus) */
                {
                    var listCarsPrice = _carRepository.Car.OrderBy(i => i.CarId);


                    List<Car> carSorted = new List<Car>();
                    List<decimal> PriceDiference = new List<decimal>();

                    foreach (var item in listCarsPrice.ToList())
                    {

                        // Add New Neural Calculate Difererence Price 
                        item.NeuralPrice = Convert.ToDecimal(Encog.Neural_Network.Encog_Neural(Convert.ToDouble(item.Price)));

                        carSorted.Add(item);
                    }

                    // Mezejimo tvarka ( nuo didesnes iki mazejancios ... ) 
                    cars = carSorted.OrderByDescending(price => price.NeuralPrice);


                    currCategory = "Klasikiniai automobiliai";
                } 
                else if(string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _carRepository.Car.Where(i => i.Category.CategoryName.Equals("Elektromobiliai")).OrderBy(i => i.CarId);
                    currCategory = "Elektromobiliai";
                }
            }

            var carObj = new CarsListViewModel
            {
                Cars = cars,
                CurrentCategory = currCategory
            };


        /* ViewBag - transfers data only controller to view */
        ViewBag.Name = " Puslapis su Automobiliais";
          /*  var carssss = _carRepository.Car;*/ /* var - tipas kuris visada gali skirtis,  cars - atgauna visus objektus, IAllCars.Car -> funkcija Car,
                                           * aprasyta paciame interfeisia, leidzianti iskviesti visus objektus, Car(-u)
                                           * Tas nevisai teisinga, taigi todel buvo sukurtas ViewModel naudojamas toliau*//*

            CarsListViewModel vm = new CarsListViewModel();
            vm.Cars = _carRepository.Car;
            vm.CurrentCategory = "CarCategory";*/
            
            return View(carObj);
       }
    }
}