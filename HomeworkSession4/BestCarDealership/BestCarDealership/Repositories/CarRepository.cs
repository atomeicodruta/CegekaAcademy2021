using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestCarDealership.Models;

namespace BestCarDealership.Repositories
{
    public class CarRepository :ICarRepository
    {
        private List<Car> _cars = new List<Car>()
        {
            //Car(int id, string manufacturer, string model, int horsePower, double price, Color color)

            new Car(1, "Audi", "Ax", 500, 750000, Color.WHITE),
            new Car(2, "Porsche", "Taycan", 999, 1000000, Color.BLACK),
            new Car(3, "Volskwagen", "Beetle", 120, 50000, Color.RED),
            new Car(4, "Honda", "Civic", 250, 250000, Color.GREEN)
        };

        public List<Car> GetCars()
        {
            return _cars;
        }

        public Car GetCarById (int id)
        {
            return _cars.FirstOrDefault(x => x.Id == id);
        }

        public void AddCar(Car newCar)
        {
            _cars.Add(newCar);
        }

        public Car UpdateCar(int id, Car car)
        {
            if (car != null)
            {
                var carToUpdate = _cars.FirstOrDefault(x => x.Id == id);

                if(carToUpdate != null)
                {
                    carToUpdate = car;
                    carToUpdate.Id = id;
                    //carToUpdate.Manufacturer = car.Manufacturer;
                    //carToUpdate.Model = car.Model;
                    //carToUpdate.HorsePower = car.HorsePower;
                    //carToUpdate.Price = car.Price;
                    //carToUpdate.Color = car.Color;

                    return carToUpdate;
                }
                return null;
            }
            return null;
        }

        public void RemoveCarById(int id)
        {
            var car = _cars.FirstOrDefault(x => x.Id == id);

            if(car != null)
            {
                _cars.Remove(car);
            }
        }
    }
}
