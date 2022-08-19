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
        private readonly LibraryContext _context;

        public RentController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Rents);
        }

        // GET api/<ValuesController>/5
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var rent = _context.Rents.FirstOrDefault(a => a.Id == id);
            if (rent == null) return BadRequest("Resultado não encontrado!");

            return Ok(rent);
        }

        [HttpPost]
        public IActionResult Post(Rent rent)
        {
            _context.Add(rent);
            _context.SaveChanges();
            return Ok(rent);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Rent rent)
        {
            var ren_t = _context.Rents.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (ren_t == null) return BadRequest("Resultado não encontrado!");

            _context.Update(rent);
            _context.SaveChanges();
            return Ok(rent);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var rent = _context.Rents.FirstOrDefault(a => a.Id == id);
            if (rent == null) return BadRequest("Resultado não encontrado!");

            _context.Remove(rent);
            _context.SaveChanges();
            return Ok();
        }


    }
}



