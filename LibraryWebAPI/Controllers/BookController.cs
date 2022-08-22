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

        public readonly IRepository _repo;
        public BookController(IRepository repo)
        {
            _repo = repo;

        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllBooks();
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var rent = _repo.GetBookById(id,true);
            if (rent == null) return BadRequest("Resultado não encontrado!");

            return Ok(rent);
        }

        [HttpPost]
        public IActionResult Post(Book book)
        {
            _repo.Add(book);
            if (_repo.SaveChanges())
            {
                return Ok(book);
            }

            return BadRequest("Aluguel não cadastrado!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Book book )
        {
            var boo_k = _repo.GetBookById(id,true);
            if (boo_k == null) return BadRequest("Resultado não encontrado!");

            _repo.Update(book);
            if (_repo.SaveChanges()) ;

            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var boo_k = _repo.GetBookById(id,true);
            if (boo_k == null) return BadRequest("Resultado não encontrado!");

            _repo.Delete(boo_k);
            if (_repo.SaveChanges())
            {
                return Ok("Liveo deletado!");
            }

            return BadRequest("Livrp não deletado!");
        }


    }
}

