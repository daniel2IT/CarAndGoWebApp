using CarAndGo.Data.Interfaces;
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
        public ViewResult List()
       {
           var cars = _carRepository.Car; /* var - tipas kuris visada gali skirtis,  cars - atgauna visus objektus, IAllCars.Car -> funkcija Car,
                                           * aprasyta paciame interfeisia, leidzianti iskviesti visus objektus, Car(-u) */
           return View(cars);
       }
    }
    }
