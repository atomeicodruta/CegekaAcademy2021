using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestCarDealership.Models;
using BestCarDealership.Repositories;


namespace BestCarDealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private static ICarRepository CarRepo;

        public CarsController(ICarRepository carRepo)
        {
            CarRepo = carRepo;
        }


        [HttpGet]   // GET: api/<CarsController> = api/Cars
        public IActionResult GetCars()
        {
            return Ok(CarRepo.GetCars());
        }


        [HttpGet("car/{id}")]   // GET api/<CarsController>/{id}
        public IActionResult GetCarById(int id)
        {
            var returnedCar = CarRepo.GetCarById(id);

            if(returnedCar == null)
                return NotFound("The car with the given id does not exist!");
            else
                return Ok(returnedCar);
        }

        
        [HttpPost]  //POST api/<CarsController>/car
        [Route("car")]
        public IActionResult AddCar([FromBody] Car car)
        {
            if (car != null)
            {
                CarRepo.AddCar(car);
                //return Ok();
                return Ok(Created(car.Id.ToString(), car));
            }
            return BadRequest();
        }


        [HttpPut("{id}")] //POST api/<CarsController>/{id}
        public IActionResult UpdateCar(int id, [FromBody] Car car)
        {
            if(CarRepo.UpdateCar(id, car) != null)
            {
                //return Ok();
                return Created(car.Id.ToString(), car);
            }

            return NotFound("The car with the given id does not exist!");
            //return BadRequest();
        }

       
        [HttpDelete("{id}")]     // DELETE api/<CarsController>/{id}
        public IActionResult Delete(int id)
        {
            if(CarRepo.RemoveCarById(id) != null)
            {
                return Ok();
            }
            return NotFound("The car with the given id does not exist!");
        }
    }
}
