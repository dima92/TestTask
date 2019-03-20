using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public ApplicationContext _db;

        public UserController(ApplicationContext context)
        {
            _db = context;
        }


        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _db.Users.ToList();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public Task<User> Get(int id)
        {
            Task<User> user = _db.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                return Ok(user);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                _db.Update(user);
                _db.SaveChanges();
                return Ok(user);
            }

            return BadRequest(ModelState);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User user = _db.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
            }
            return Ok(user);
        }
    }
}
