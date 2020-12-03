using CarAndGo.Data;
using CarAndGo.Data.Interfaces;
using CarAndGo.Data.Models;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public IActionResult Checkout()
        { /* IActionResult - pas mus View(-e) bus naudojama Forma, ir is jos reikes atgauti duomen. tai ir 
                                         * tam yra jisai naudojamas, nes jas pades atgaut */

            return View();
        }

        [HttpPost] /* Kai gausime Post Request is View (method="post"), tai reiskia ....kada eina post, butinas panaudotas turi 
                    buti tas modelis , musu atveju @model Order, na ir tiesiog cia parasom, kad mes priimame parametra Order
                                                                                                        Checkout(Order order)*/
        [Authorize]
        public IActionResult Checkout(Order order)
        { /* IActionResult - pas mus View(-e) bus naudojama Forma, ir is jos reikes atgauti duomen. tai ir 
                                         * tam yra jisai naudojamas, nes jas pades atgaut */

            shopCart.listShopItems = shopCart.getShopItems(); /* tiesiog paimam visus Isrinktus pirkimui prekes ir jas priskiriam listui*/

            if(shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("","Pas jus turi buti Pasirinkti Prekes"); /* klase atvaizduojama Errora */
            }

            if(ModelState.IsValid) /* IsValid bus tik tada, kai Validacija praeina ...*/
            {
                allOrders.createOrder(order); /* leidzia sukurti nauja uzsakyma 
                                               order - tai visi Name,Surname,PhoneNumber...*/
                return RedirectToAction("Complete"); /* Complete - funkcija kuri sukursime */
            }


            return View();
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Uzsakymas sekmingai apdorotas...";
            return View();
        }
    }
}
