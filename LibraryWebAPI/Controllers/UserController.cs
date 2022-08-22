using LibraryWebAPI.Data;
using LibraryWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        public readonly IRepository _repo;

        public UserController(IRepository repo)
        {
            _repo = repo;
           
        }
        // GET: api/<ValuesController>

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllUsers();
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _repo.GetUserById(id);
            if (user == null) return BadRequest("Usuário não encontrado!");

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            _repo.Add(user);
            if (_repo.SaveChanges())
            {
                return Ok(user);
            }

            return BadRequest("Usuário não cadastrado!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, User user)
        {
            var use_r = _repo.GetUserById(id);
            if (use_r == null) return BadRequest("Usuário não encontrado!");


            _repo.Update(user);
            if (_repo.SaveChanges())
            {
                return Ok(user);
            }

            return BadRequest("Usuário não cadastrado!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var use_r = _repo.GetUserById(id);
            if (use_r == null) return BadRequest("Usuário não encontrado!");

            _repo.Delete(use_r);
            if (_repo.SaveChanges())
            {
                return Ok("Usuário deletado!");
            }

            return BadRequest("Usuário não deletado!");


        }
    }

}



