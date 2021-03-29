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
        private readonly ICarRepository CarRepo;

        public CarsController(ICarRepository carRepo)
        {
            CarRepo = carRepo;
        }

        // GET: api/<CarsController>
        [HttpGet]
        public IActionResult GetCars()
        {
            return Ok(CarRepo.GetCars());
        }

        // GET api/<CarsController>/5
        [HttpGet("car/{id}")]
        public Car GetCarById(int id)
        {
            return CarRepo.GetCarById(id);
        }

        //POST api/<CarsController>
        [HttpPost]
        [Route("car")]
        public IActionResult AddCar([FromBody] Car car)
        {
            if (car != null)
            {
                CarRepo.AddCar(car);
                //return Ok();
                //CarRepo.AddCar(car);
                return Created(car.Id.ToString(),car);
            }
            return BadRequest();
        }

        private IActionResult UpdateCar([FromBody] int id, [FromBody] Car car)
        {
            throw new NotImplementedException();
        }

        // PUT api/<CarsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
