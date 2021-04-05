using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAndGo.Data.Models
{
    public class Car
    {
        public int CarId { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public decimal Price { get; set; }

        public decimal? NeuralPrice { get; set; }

        public string ImageUrl { get; set; }

        public string ImageThumbnaiUrl { get; set; }

        public bool IsPreferredCar { get; set; }

        public bool InStock { get; set; }

        /* Foreign Key */
        public int CategoryId { get; set; }

       /* turi tik viena */
        public virtual Category Category { get; set; }

    }
}
