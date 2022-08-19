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
    public class PublisherController : ControllerBase
    {
        private readonly LibraryContext _context;

        public PublisherController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Publishers);
        }

        // GET api/<ValuesController>/5
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var publisher = _context.Publishers.FirstOrDefault(a => a.Id == id);
            if (publisher == null) return BadRequest("Editora não encontrada!");

            return Ok(publisher);
        }

        [HttpPost]
        public IActionResult Post(Publisher publisher)
        {
            _context.Add(publisher);
            _context.SaveChanges();
            return Ok(publisher);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Publisher publisher)
        {
            var publishe_r = _context.Publishers.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (publishe_r == null) return BadRequest("Editora não encontrada!");

            _context.Update(publisher);
            _context.SaveChanges();
            return Ok(publisher);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var publisher = _context.Publishers.FirstOrDefault(a => a.Id == id);
            if (publisher == null) return BadRequest("Editora não encontrada!");

            _context.Remove(publisher);
            _context.SaveChanges();
            return Ok();
        }


    }
}

