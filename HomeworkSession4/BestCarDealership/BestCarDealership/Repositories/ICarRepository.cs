using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestCarDealership.Models;

namespace BestCarDealership.Repositories
{
    public interface ICarRepository
    {
        public List<Car> GetCars();

        public Car GetCarById(int id);

        public void AddCar(Car newCar);

        public Car UpdateCar(int id, Car car);

        public void RemoveCarById(int id);

    }
}
