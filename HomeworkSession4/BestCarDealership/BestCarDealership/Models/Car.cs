using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestCarDealership.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public double Price { get; set; }

        public Car(int id, string manufacturer, string model, int horsePower, double price)
        {
            Id = id;
            Manufacturer = manufacturer;
            Model = model;
            HorsePower = horsePower;
            Price = price;
        }

        //public Car(Car c) : this(c.Id, c.Manufacturer, c.Model, c.HorsePower, c.Price) { }

    }
}
