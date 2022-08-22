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
        public readonly IRepository _repo;
        public PublisherController(IRepository repo)
        {
            _repo = repo;

        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllPublishers();
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var publisher = _repo.GetPublisherById(id);
            if (publisher == null) return BadRequest("Resultado não encontrado!");

            return Ok(publisher);
        }

        [HttpPost]
        public IActionResult Post(Publisher publisher)
        {
            _repo.Add(publisher);
            if (_repo.SaveChanges())
            {
                return Ok(publisher);
            }

            return BadRequest("Editora não cadastrada!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Publisher publisher)
        {
            var publishe_r = _repo.GetPublisherById(id);
            if (publishe_r == null) return BadRequest("Resultado não encontrado!");

            _repo.Update(publisher);
            if (_repo.SaveChanges()) ;

            return Ok(publisher);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var publishe_r = _repo.GetPublisherById(id);
            if (publishe_r == null) return BadRequest("Resultado não encontrado!");

            _repo.Delete(publishe_r);
            if (_repo.SaveChanges())
            {
                return Ok("Editora deletada!");
            }

            return BadRequest("Editora não deletada!");
        }


    }
}

