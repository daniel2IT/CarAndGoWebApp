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
        IEnumerable<Car> Car { get; set; }

        /* Setted Cars */
        IEnumerable<Car> PreferredCars { get; set; }

        /* for one */
        Car getCarById(int carId);

    }
}
