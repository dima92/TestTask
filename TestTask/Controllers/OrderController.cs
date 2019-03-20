using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public ApplicationContext _db;

        public OrderController(ApplicationContext context)
        {
            _db = context;
        }



        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _db.Orders.ToList();
        }


        [HttpGet("{id}")]
        public Task<Order> Get(int id)
        {
            Task<Order> order = _db.Orders.FirstOrDefaultAsync(x => x.Id == id);
            return order;
        }


        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            if (ModelState.IsValid)
            {
                _db.Orders.Add(order);
                _db.SaveChanges();
                return Ok(order);
            }
            return BadRequest(ModelState);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Order order)
        {
            if (ModelState.IsValid)
            {
                _db.Update(order);
                _db.SaveChanges();
                return Ok(order);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Order order = _db.Orders.FirstOrDefault(x => x.Id == id);
            if (order != null)
            {
                _db.Orders.Remove(order);
                _db.SaveChanges();
            }
            return Ok(order);
        }
    }
}
