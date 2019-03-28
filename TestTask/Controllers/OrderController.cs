using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using TestTask.Models;
using TestTask.ModelsDto;

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
        public IActionResult Get(string stat)
        {
            try
            {
                List<OrderDto> result = new List<OrderDto>();
                List<Order> allOrders = _db.Orders.Include(tab => tab.Car).Include(us => us.User).
                    OrderBy(u => u.User.Name).
                    ThenBy(u => u.Car.Mark).
                    ThenBy(u => u.Car.Model).
                    ThenBy(u => u.StartDate).
                    ThenBy(u => u.EndDate).
                    Where(r => r.User.Name.StartsWith(stat.Substring(0, 4))).ToList();

                foreach (var order in allOrders)
                {
                    result.Add(new OrderDto
                    {
                        Car = $"{order.Car.Mark} {order.Car.Model}",
                        CarId = order.CarId,
                        User = $"{order.User.Name} {order.User.LastName}",
                        UserId = order.UserId,
                        StartDate = order.StartDate,
                        EndDate = order.EndDate,
                        Rent = order.Rent,
                        Description = order.Description
                    });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest(ModelState);
            }
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
