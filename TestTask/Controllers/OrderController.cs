using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TestTask.Models;
using TestTask.ModelsDto;

namespace TestTask.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public ApplicationContext Db;

        public OrderController(ApplicationContext context)
        {
            Db = context;
        }



        [HttpGet]
        public IActionResult Get(string avto, string startDate, string endDate, string user)
        {
            try
            {
                List<OrderDto> result = new List<OrderDto>();
                List<Order> allOrders = Db.Orders.Include(tab => tab.Car).Include(us => us.User).ToList();
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

                result = result.OrderByDescending(x => x.StartDate).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Add new order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add([FromBody] Order order)
        {
            if (ModelState.IsValid)
            {
                Db.Orders.Add(order);
                Db.SaveChanges();
                return Ok(order);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Edit Order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Edit([FromBody] OrderDto order)
        {
            if (ModelState.IsValid)
            {
                Order ord = new Order();
                ord.CarId = order.CarId;
                ord.UserId = order.UserId;
                ord.Description = order.Description;
                ord.Rent = order.Rent;
                ord.StartDate = order.StartDate;
                ord.EndDate = order.EndDate;
                ord.Id = order.Id;
                Db.Orders.Update(ord);
                Db.SaveChanges();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Order order = Db.Orders.FirstOrDefault(x => x.Id == id);
            if (order != null)
            {
                Db.Orders.Remove(order);
                Db.SaveChanges();
            }
            return Ok(order);
        }
    }
}
