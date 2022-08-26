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
    public class PublisherController : ControllerBase
    {
        public readonly IRepository _repo;

        public readonly IMapper _mapper;

        public PublisherController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            var publishers = _repo.GetAllPublishers();

            return Ok(_mapper.Map<IEnumerable<PublisherDto>>(publishers));
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var publisher = _repo.GetPublisherById(id);
            if (publisher == null) return BadRequest("Resultado não encontrado!");

            var publisherDto = _mapper.Map<PublisherDto>(publisher);

            return Ok(publisherDto);
        }

        [HttpPost]
        public IActionResult Post(PublisherDto model)
        {
            var publisher = _mapper.Map<Publisher>(model);

            _repo.Add(publisher);
            if (_repo.SaveChanges())
            {
                return Created($"/api/publisher/{model.Id}", _mapper.Map<PublisherDto>(publisher));
            }

            return BadRequest("Editora não cadastrada!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, PublisherDto model)
        {
            var publisher = _repo.GetPublisherById(id);
            if (publisher == null) return BadRequest("Editora não atualizada!");

            _mapper.Map(model, publisher);

            _repo.Update(publisher);
            if (_repo.SaveChanges()) ;
            {
                return Created($"/api/publisher/{model.Id}", _mapper.Map<PublisherDto>(publisher));
            }

            return BadRequest("Editora não atualizada!");
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

