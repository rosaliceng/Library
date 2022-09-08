using AutoMapper;
using LibraryWebAPI.Data;
using LibraryWebAPI.Dto;
using LibraryWebAPI.Dto.Publishers;
using LibraryWebAPI.Helpers;
using LibraryWebAPI.Models;
using LibraryWebAPI.Services.Publishers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryWebAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}[controller]")]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public readonly IRepository _repo;

        public readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public PublisherController(IPublisherService service,IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
            _publisherService = service;

        }
        /// <summary>
        /// Método responsavel por retornar todos os meus usários.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageParams pageParams)
        {
            var publishers = await _repo.GetAllPublishersAsync(pageParams);

            var publishersResult = _mapper.Map<IEnumerable<PublisherResponseDto>>(publishers);

            Response.AddPagination(publishers.CurrentPage, publishers.PageSize, publishers.TotalCount, publishers.TotalPages);

            return Ok(publishersResult);
        }

        /// <summary>
        /// Método responsavel por retornar um único UserDTO.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var publisher = _repo.GetPublisherById(id);
            if (publisher == null) return BadRequest("Livro não encontrado!");

            var publisherDto = _mapper.Map<PublisherResponseDto>(publisher);

            return Ok(publisherDto);
        }

        [HttpPost]
        public IActionResult Post(PublisherRequestDto model)
        {
            var result = _publisherService.PublisherCreate(_mapper.Map<Publisher>(model));

            if (result != null)
            {
                return Created($"/api/v1publisher/{result.Id}", _mapper.Map<PublisherResponseDto>(result));
            }

            return BadRequest("Editora não cadastrada!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, PublisherRequestDto model)
        {
            var result = _publisherService.PublisherUpdate(id, _mapper.Map<Publisher>(model));

            if (result != null)
            {
                return Created($"/api/publisher/{result.Id}", _mapper.Map<PublisherResponseDto>(result));
            }

            return BadRequest("Editora não atualizada!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _publisherService.PublisherDelete(id);

            if (result != null)
            {
                return Ok("Editora deletada.");
            }

            return BadRequest("Editora não deletada!");


        }
    }

}



