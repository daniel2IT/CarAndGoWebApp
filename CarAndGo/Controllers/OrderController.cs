using CarAndGo.Data;
using CarAndGo.Data.Interfaces;
using CarAndGo.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAndGo.Controllers
{
    public class OrderController : Controller
    {
        /* Db sukurimas/redagavimas/atgavimas */
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        public IActionResult Checkout() /* IActionResult - pas mus View(-e) bus naudojama Forma, ir is jos reikes atgauti duomen. tai ir 
                                         * tam yra jisai naudojamas, nes jas pades atgaut */
        {
            return View();
        }

    }
}
