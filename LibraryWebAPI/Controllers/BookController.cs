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
    public class BookController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BookController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Books);
        }

        // GET api/<ValuesController>/5
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var book = _context.Books.FirstOrDefault(a => a.Id == id);
            if (book == null) return BadRequest("Livro não encontrado!");

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
            return Ok(book);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Book book)
        {
            var boo_k = _context.Books.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (boo_k == null) return BadRequest("Livro não encontrado!");

            _context.Update(book);
            _context.SaveChanges();
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _context.Users.FirstOrDefault(a => a.Id == id);
            if (book == null) return BadRequest("Livro não encontrado!");

            _context.Remove(book);
            _context.SaveChanges();
            return Ok();
        }


    }
}

