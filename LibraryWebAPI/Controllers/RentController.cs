using AutoMapper;
using LibraryWebAPI.Data;
using LibraryWebAPI.Dto;
using LibraryWebAPI.Dto.Rents;
using LibraryWebAPI.Helpers;
using LibraryWebAPI.Models;
using LibraryWebAPI.Services.Rents;
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
    [Route("api/v{version:apiVersion}/[controller]")]
    public class RentController : ControllerBase
    {
        private readonly IRentService _rentService;

        public readonly IRepository _repo;

        public readonly IMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public RentController(IRentService service,IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
            _rentService = service;

        }
        /// <summary>
        /// Método responsavel por retornar todos os meus usários.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageParams pageParams)
        {
            var rents = await _repo.GetAllRentsAsync(pageParams);

            var rentsResult = _mapper.Map<IEnumerable<RentResponseDto>>(rents);

            Response.AddPagination(rents.CurrentPage, rents.PageSize, rents.TotalCount, rents.TotalPages);

            return Ok(rentsResult);
        }

        /// <summary>
        /// Método responsavel por retornar um único UserDTO.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var rent = _repo.GetRentById(id);
            if (rent == null) return BadRequest("Aluguel não encontrado!");

            var rentDto = _mapper.Map<RentResponseDto>(rent);

            return Ok(rentDto);
        }

        [HttpPost]
        public IActionResult Post(RentRequestDto model)
        {
            var result = _rentService.RentCreate(_mapper.Map<Rent>(model));

            if (result != null)
            {
                return Created($"/api/v1/rent/{result.Id}", _mapper.Map<RentResponseDto>(result));
            }
            return BadRequest("Aluguel não cadastrado!");
        }

        [HttpPut("{id}")]
        public IActionResult Put( RentDevolutionDto model)
        {
            var result = _rentService.RentUpdate(_mapper.Map<Rent>(model));

            if (result != null)
            {
                return Created($"/api/rent/{result.Id}", _mapper.Map<RentResponseDto>(result));
            }

            return BadRequest("Não foi possível atualizar aluguel.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _rentService.RentDelete(id);

            if (result != null)
            {
                return Ok("Aluguel deletado.");
            }

            return BadRequest("Aluguel não deletado!");


        }
    }

}




