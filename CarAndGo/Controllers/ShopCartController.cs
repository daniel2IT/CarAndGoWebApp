using CarAndGo.Data.Interfaces;
using CarAndGo.Data.Models;
using CarAndGo.Data.Repository;
using CarAndGo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAndGo.Controllers
{
    public class ShopCartController : Controller
    {
        private ICarRepository _carRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(ICarRepository carRep, ShopCart shopCart)
        {
            _carRep = carRep;
            _shopCart = shopCart;
        }

        /* FUNKCIJA - leidzianti iskviesti HTML sablona ir atvaizduoti */
        public ViewResult Index()
        {
            var items = _shopCart.getShopItems(); /* Paima prekes (Is db) */
            _shopCart.listShopItems = items; /* Priskiria prekes */

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart /* Priskirimas */
            };

            return View(obj); /* Priskirto Objekto Returninimas */
        }

        /* FUNKCIJA - Prideda prekes i krepseli ir LEIS pereadresuoti i kita puslapi Kur yra Logika */
        /* FUNKCIJA - Prideda prekes i krepseli ir LEIS pereadresuoti i kita puslapi Kur yra Logika */
        /* RedirectToActionResult - duomenu tipas kuris mus grazintas */
        public RedirectToActionResult addToCart(int id)
        { /* _carRep - prekiu saugykla, FirstOrDefault - rastas, arba pirmas */
            var item = _carRep.Car.FirstOrDefault(i => i.CarId == id); /*is duom bazes paims reikalinga preke */
            if(item != null)
            {
                _shopCart.AddToCart(item);
            }

            /* Po prekes pridejimo mes esame Redirectinami i Krepseli */
            return RedirectToAction("Index"); /* i koki puslapi busime perkelti */
        }

       }
}
