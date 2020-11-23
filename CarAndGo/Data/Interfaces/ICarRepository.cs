using CarAndGo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAndGo.Data.Interfaces
{
    public interface ICarRepository
    {
        /* use to get all Cars */
        IEnumerable<Car> Car { get;}

        /* Setted Cars */
        IEnumerable<Car> PreferredCars { get;  }

        /* for one */
        Car getCarById(int carId);

    }
}
