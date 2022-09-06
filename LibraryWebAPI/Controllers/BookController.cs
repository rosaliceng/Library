using AutoMapper;
using LibraryWebAPI.Data;
using LibraryWebAPI.Dto;
using LibraryWebAPI.Dto.Books;
using LibraryWebAPI.Helpers;
using LibraryWebAPI.Models;
using LibraryWebAPI.Services.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryWebAPI.Controllers
{   /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}[controller]")]
    public class BookController : ControllerBase
    {
        public readonly IBookService _bookService;

        public readonly IRepository _repo;

        public readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public BookController(IBookService service,IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
            _bookService = service;
        }
        /// <summary>
        /// Método responsavel por retornar todos os meus usários.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageParams pageParams)
        {
            var books = await _repo.GetAllBooksAsync(pageParams);

            var booksResult = _mapper.Map<IEnumerable<BookResponseDto>>(books);

            Response.AddPagination(books.CurrentPage, books.PageSize, books.TotalCount, books.TotalPages);

            return Ok(booksResult);
        }

        /// <summary>
        /// Método responsavel por retornar um único UserDTO.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _repo.GetBookById(id);
            if (book == null) return BadRequest("Livro não encontrado!");

            var bookDto = _mapper.Map<BookResponseDto>(book);

            return Ok(bookDto);
        }

        [HttpPost]
        public IActionResult Post(BookRequestDto model)
        {
            var result = _bookService.BookCreate( _mapper.Map<Book>(model));

            if (result != null)
            {
                return Created($"/api/v1book/{result.Id}", _mapper.Map<BookResponseDto>(result));
            }
            return BadRequest("Livro não atualizado!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, BookRequestDto model)
        {
            var result = _bookService.BookUpdate(id, _mapper.Map<Book>(model));

            if (result != null)
            {
                return Created($"/api/v1book/{result.Id}", _mapper.Map<BookResponseDto>(result));
            }

            return BadRequest("Livro não cadastrado!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _repo.GetBookById(id);
            if (book == null) return BadRequest("Livro não encontrado!");

            _repo.Delete(book);
            if (_repo.SaveChanges())
            {
                return Ok("Usuário deletado!");
            }

            return BadRequest("Livro não deletado!");


        }
    }

}


