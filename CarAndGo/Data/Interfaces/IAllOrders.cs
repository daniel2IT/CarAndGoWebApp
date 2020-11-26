using CarAndGo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAndGo.Data.Interfaces
{
    public interface IAllOrders
    {
        void createOrder(Order order); /* Funkcija Orderio/Uzsakymo sukurimas */
    }
}
