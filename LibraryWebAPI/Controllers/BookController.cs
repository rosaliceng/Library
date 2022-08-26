using AutoMapper;
using LibraryWebAPI.Data;
using LibraryWebAPI.Dto;
using LibraryWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryWebAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}[controller]")]
    public class BookController : ControllerBase
    {
        public readonly IRepository _repo;

        public readonly IMapper _mapper;

        public BookController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            var books = _repo.GetAllBooks();

            return Ok(_mapper.Map<IEnumerable<BookDto>>(books));
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _repo.GetBookById(id, true);
            if (book == null) return BadRequest("Resultado não encontrado!");

            var bookDto = _mapper.Map<BookDto>(book);

            return Ok(bookDto);
        }

        [HttpPost]
        public IActionResult Post(BookDto model)
        {
            var book = _mapper.Map<Book>(model);

            _repo.Add(book);
            if (_repo.SaveChanges())
            {
                return Created($"/api/book/{model.Id}", _mapper.Map<BookDto>(book));
            }

            return BadRequest("Livro não atualizado!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, BookDto model)
        {
            var book = _repo.GetBookById(id, true);
            if (book == null) return BadRequest("Resultado não encontrado!");

            _mapper.Map(model, book);


            _repo.Update(book);
            if (_repo.SaveChanges())
            {
                return Created($"/api/book/{model.Id}", _mapper.Map<BookDto>(book));
            }

            return BadRequest("Usuário não cadastrado!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _repo.GetBookById(id, true);
            if (book == null) return BadRequest("Resultado não encontrado!");

            _repo.Delete(book);
            if (_repo.SaveChanges())
            {
                return Ok("Livro deletado!");
            }

            return BadRequest("Livro não deletado!");
        }


    }
}

