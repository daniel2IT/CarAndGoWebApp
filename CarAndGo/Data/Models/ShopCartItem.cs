using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAndGo.Data.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Car car { get; set;  }
        public int price { get; set; }

        public string ShopCartId { get; set; }
    }
}
