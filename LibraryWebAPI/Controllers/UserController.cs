﻿using AutoMapper;
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
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}[controller]")]
    public class UserController : ControllerBase
    {

        public readonly IRepository _repo;

        public readonly IMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public UserController(IRepository repo,IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
           
        }
        /// <summary>
        /// Método responsavel por retornar todos os meus usários.
        /// </summary>
        /// <returns></returns>
    
        [HttpGet]
        public IActionResult Get()
        {
            var  users = _repo.GetAllUsers();

            return Ok(_mapper.Map<IEnumerable<UserDto>>(users));
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

            var userDto = _mapper.Map<UserDto>(user);

            return Ok(userDto);
        }

        [HttpPost]
        public IActionResult Post(UserDto model)
        {
            var user = _mapper.Map<User>(model);

            _repo.Add(user);
            if (_repo.SaveChanges())
            {
                return Created($"/api/user/{model.Id}", _mapper.Map<UserDto>(user));
            }

            return BadRequest("Usuário não atualizado!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UserDto model)
        {
            var user = _repo.GetUserById(id);
            if (user == null) return BadRequest("Usuário não cadastrado!");

            _mapper.Map(model, user);


            _repo.Update(user);
            if (_repo.SaveChanges())
            {
                return Created($"/api/user/{model.Id}", _mapper.Map<UserDto>(user));
            }

            return BadRequest("Usuário não cadastrado!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _repo.GetUserById(id);
            if (user == null) return BadRequest("Usuário não encontrado!");

            _repo.Delete(user);
            if (_repo.SaveChanges())
            {
                return Ok("Usuário deletado!");
            }

            return BadRequest("Usuário não deletado!");


        }
    }

}


