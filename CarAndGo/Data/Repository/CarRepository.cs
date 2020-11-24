using CarAndGo.Data.Interfaces;
using CarAndGo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAndGo.Data.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDBContent appDBContent;

        /* atgavimas/interactive duomenu is/su DB*/
        public CarRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Car> Car => appDBContent.Car.Include(c => c.Category); /* Atgauname visus duom */

        public IEnumerable<Car> PreferredCars => appDBContent.Car.Where(p => p.IsPreferredCar).Include(c=> c.Category); /* Atgauname visus duom kur IsPreferredCar is true  */


        public Car getCarById(int carId) => appDBContent.Car.FirstOrDefault(p => p.CarId == carId); /* atgaunamas tik 1 objektas su id */
            
    }
}
