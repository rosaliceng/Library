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
    public class RentController : ControllerBase
    {

        public readonly IRepository _repo;
        public RentController(IRepository repo)
        {
            _repo = repo;   
            
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllRents();
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var rent = _repo.GetRentById(id, id);
            if (rent == null) return BadRequest("Resultado não encontrado!");

            return Ok(rent);
        }

        [HttpPost]
        public IActionResult Post(Rent rent)
        {
            _repo.Add(rent);
            if (_repo.SaveChanges())
            {
                return Ok(rent);
            }

            return BadRequest("Aluguel não cadastrado!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Rent rent)
        {
            var ren_t = _repo.GetRentById(id, id);
            if (ren_t == null) return BadRequest("Resultado não encontrado!");

            _repo.Update(rent);
            if (_repo.SaveChanges());

            return Ok(rent);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ren_t = _repo.GetRentById(id, id);
            if (ren_t == null) return BadRequest("Resultado não encontrado!");

            _repo.Delete(ren_t);
            if (_repo.SaveChanges())
            {
                return Ok("Aluguel deletado!");
            }

            return BadRequest("Aluguel não deletado!");
        }


    }
}



