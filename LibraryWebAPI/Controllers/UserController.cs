using AutoMapper;
using LibraryWebAPI.Data;
using LibraryWebAPI.Dto;
using LibraryWebAPI.Dto.Users;
using LibraryWebAPI.Helpers;
using LibraryWebAPI.Models;
using LibraryWebAPI.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryWebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public readonly IRepository _repo;

        public readonly IMapper _mapper;
       /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public UserController(IUserService service,IRepository repo,IMapper mapper)
        { 
            _mapper = mapper;
            _repo = repo;
            _userService = service;
        }
        /// <summary>
        /// Método responsavel por retornar todos os meus usários.
        /// </summary>
        /// <returns></returns>
    
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageParams pageParams) 
        {
            var  users = await _repo.GetAllUsersAsync(pageParams);

            var usersResult = _mapper.Map<IEnumerable<UserResponseDto>>(users);

            Response.AddPagination(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);

            return Ok(usersResult);
        }

        /// <summary>
        /// Método responsavel por retornar um único UserDTO.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _repo.GetUserById(id);
            if (user == null) return BadRequest("Usuário não encontrado!");

            var userDto = _mapper.Map<UserResponseDto>(user);

            return Ok(userDto);
        }

        [HttpPost]
        public IActionResult Post(UserRequestDto model)
        {
            var result = _userService.UserCreate(_mapper.Map<User>(model));

            if (result != null)
            {
                return Created($"/api/v1/user/{result.Id}", _mapper.Map<UserResponseDto>(result));
            }
            return BadRequest("Usuário não cadastrado!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UserRequestDto model)
        {
            var result = _userService.UserUpdate(id, _mapper.Map<User>(model));

            if (result != null)
            {
                return Created($"/api/user/{result.Id}", _mapper.Map<UserResponseDto>(result));
            }

            return BadRequest("Usuário não atualizado!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _userService.UserDelete(id);

            if (result != null)
            {
                return Ok("Usuário deletado.");
            }
            return BadRequest("Usuário não deletado!");


        }
    }

}


