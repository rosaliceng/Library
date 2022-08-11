using LibraryWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        public List<User> Users = new List<User>()
        {
            new User()
            {
                Id = 1,
                Name = "Artur",
                City = "Fortaleza",
                Address = "Rua A",
                Email = "artur@gmail.com"

            },


            new User()
            {
                Id = 2,
                Name = "Rosa",
                City = "Fortaleza",
                Address = "Rua A",
                Email = "rosa@gmail.com"

            },


            new User()
            {
                Id = 3,
                Name = "Leo",
                City = "Fortaleza",
                Address = "Rua A",
                Email = "leo@gmail.com"

            }
        };

        public UserController() { }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Users);
        }

        // GET api/<ValuesController>/5
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var user = Users.FirstOrDefault(a => a.Id == id);
            if (user == null) return BadRequest("Usuário não encontrado!");

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, User user)
        {
            
            return Ok(user);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {

            return Ok();
        }

    }
}

