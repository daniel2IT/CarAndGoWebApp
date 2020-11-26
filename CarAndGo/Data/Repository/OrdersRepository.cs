using CarAndGo.Data.Interfaces;
using CarAndGo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAndGo.Data.Repository
{
    /* Realizuoja Interfeiso funkcija */
    public class OrdersRepository : IAllOrders
    {

        /* Db sukurimas/redagavimas/atgavima */
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart ) 
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }
        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order); /* Uzsakymas added to table Order*/

            var items = shopCart.listShopItems; /* prekes kurias uzsako naudotojas */

            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarID = el.car.CarId,
                    orderID = order.id,
                    price = Convert.ToUInt32(el.car.Price)
                };
                appDBContent.OrderDetail.Add(orderDetail);
            }
            appDBContent.SaveChanges();
        }
    }
}
