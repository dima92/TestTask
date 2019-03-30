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
        public IActionResult Get(string avto, string startDate, string endDate, string user)
        {
            try
            {
                List<OrderDto> result = new List<OrderDto>();
                List<Order> allOrders = _db.Orders.Include(tab => tab.Car).Include(us => us.User).ToList();
                foreach (var order in allOrders)
                {
                    result.Add(new OrderDto
                    {
                        Id = order.Id,
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

                if (startDate != null)
                {
                    DateTime stDate = Convert.ToDateTime(startDate);
                    result = result.Where(w => w.StartDate.Date == stDate.Date).ToList();
                }

                if (avto != null)
                {
                    result = result.Where(w => w.Car.StartsWith(avto)).ToList();
                }

                if (endDate != null)
                {
                    DateTime enDate = Convert.ToDateTime(endDate);
                    result = result.Where(w => w.EndDate.Date == enDate.Date).ToList();
                }

                if (user != null)
                {
                    result = result.Where(w => w.User.StartsWith(user)).ToList();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest(ModelState);
            }
        }


        //[HttpGet("{id}")]
        //public Task<Order> Get(int id)
        //{
        //    Task<Order> order = _db.Orders.FirstOrDefaultAsync(x => x.Id == id);
        //    return order;
        //}


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
