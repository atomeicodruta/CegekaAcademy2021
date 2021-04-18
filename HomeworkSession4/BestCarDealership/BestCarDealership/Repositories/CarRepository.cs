using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestCarDealership.Models;

namespace BestCarDealership.Repositories
{
    public class CarRepository :ICarRepository
    {
        protected static List<Car> _cars = new List<Car>()
        {
            //Car(int id, string manufacturer, string model, int horsePower, double price)

            new Car(1, "Audi", "Ax", 500, 750000),
            new Car(2, "Porsche", "Taycan", 999, 1000000),
            new Car(3, "Volskwagen", "Beetle", 120, 50000),
            new Car(4, "Honda", "Civic", 250, 250000)
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
                    if(car.Id != 0)
                        carToUpdate.Id = car.Id;
                    if(car.Manufacturer != null)
                        carToUpdate.Manufacturer = car.Manufacturer;
                    if(car.Model != null)
                        carToUpdate.Model = car.Model;
                    if (car.HorsePower != 0)
                        carToUpdate.HorsePower = car.HorsePower;
                    if (car.Price >= 0)
                        carToUpdate.Price = car.Price;
                   
                    return carToUpdate;
                }
                return null;
            }
            return null;
        }

        public Car RemoveCarById(int id)
        {
            var car = _cars.FirstOrDefault(x => x.Id == id);

            if(car != null)
            {
                _cars.Remove(car);
                return car;
            }
            return null;
        }
    }
}
