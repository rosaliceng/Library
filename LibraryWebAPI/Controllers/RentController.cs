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
    public class RentController : ControllerBase
    {
        public readonly IRepository _repo;

        public readonly IMapper _mapper;

        public RentController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }
        // GET: api/<ValuesController>

        [HttpGet]
        public IActionResult Get()
        {
            var rents = _repo.GetAllRents();

            return Ok(_mapper.Map<IEnumerable<RentDto>>(rents));
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var rent = _repo.GetRentById(id, id);
            if (rent == null) return BadRequest("Aluguel não encontrado!");

            var rentDto = _mapper.Map<RentDto>(rent);

            return Ok(rentDto);
        }

        [HttpPost]
        public IActionResult Post(RentDto model)
        {
            var rent = _mapper.Map<Rent>(model);

            _repo.Add(rent);
            if (_repo.SaveChanges())
            {
                return Created($"/api/rent/{model.Id}", _mapper.Map<RentDto>(rent));
            }

            return BadRequest("Aluguel não cadastrado!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, RentDto model)
        {
            var rent = _repo.GetRentById(id,id);
            if (rent == null) return BadRequest("Usuário não encontrado!");

            _mapper.Map(model, rent);

            _repo.Update(rent);
            if (_repo.SaveChanges())
            {
                return Created($"/api/rent/{model.Id}", _mapper.Map<RentDto>(rent));
            }

            return BadRequest("Aluguel não cadastrado!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ren_t = _repo.GetRentById(id,id);
            if (ren_t == null) return BadRequest("Aluguel não encontrado!");

            _repo.Delete(ren_t);
            if (_repo.SaveChanges())
            {
                return Ok("Aluguel deletado!");
            }

            return BadRequest("Aluguel não deletado!");


        }
    }

}




