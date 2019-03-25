using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Models;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        public ApplicationContext _db;

        public CarController(ApplicationContext context)
        {
            _db = context;
        }



        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _db.Cars.ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest(ModelState);
            }



        }

        [HttpGet("{id}")]
        public Task<Car> Get(int id)
        {
            Task<Car> car = _db.Cars.FirstOrDefaultAsync(x => x.Id == id);
            return car;
        }


        [HttpPost]
        public IActionResult Post([FromBody] Car car)
        {
            if (ModelState.IsValid)
            {
                _db.Cars.Add(car);
                _db.SaveChanges();
                return Ok(true);
            }
            return BadRequest(ModelState);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Car car)
        {
            if (ModelState.IsValid)
            {
                _db.Update(car);
                _db.SaveChanges();
                return Ok(car);
            }

            return BadRequest(ModelState);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Car car = _db.Cars.FirstOrDefault(x => x.Id == id);
            if (car != null)
            {
                _db.Cars.Remove(car);
                _db.SaveChanges();
            }
            return Ok(car);
        }
    }
}
