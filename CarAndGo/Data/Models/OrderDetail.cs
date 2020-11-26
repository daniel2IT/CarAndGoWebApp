using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAndGo.Data.Models
{
    public class OrderDetail
    {
        public int id { get; set; } /* DUom Bazes */
        public int orderID{ get; set; } /*Uzsakymo */
        public int CarID { get; set; } /* Konkretas isigito automobilio id */
        public uint price { get; set; } /* bendra */
        public virtual Car car { get; set; } /*  reikalingas tiesiog parodyti DB rysi */
        public virtual Order Order{ get; set; } /* 2 tie virtual atsakingi uz Objekta ir uzsakyma su kuriais dirbame */

  /*      public List<OrderDetail> orderDetails { get; set; } *//* Aprasymas prekiu kurias isigijam */
    }
}
