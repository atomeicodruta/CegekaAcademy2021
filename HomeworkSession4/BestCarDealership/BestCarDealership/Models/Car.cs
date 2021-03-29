using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestCarDealership.Models
{
    public enum Color
    {
        WHITE,
        GREEN,
        RED,
        BLUE,
        BLACK
    }
    public class Car
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public double Price { get; set; }
        public Color Color { get; set; }

        public Car(int id, string manufacturer, string model, int horsePower, double price, Color color)
        {
            Id = id;
            Manufacturer = manufacturer;
            Model = model;
            HorsePower = horsePower;
            Price = price;
            Color = color;
        }

    }
}
