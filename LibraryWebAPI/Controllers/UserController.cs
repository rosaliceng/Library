﻿using LibraryWebAPI.Data;
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
      public class UserController : ControllerBase
    {
        private readonly LibraryContext _context;

        public UserController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Users);
        }

        // GET api/<ValuesController>/5
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var user = _context.Users.FirstOrDefault(a => a.Id == id);
            if (user == null) return BadRequest("Usuário não encontrado!");

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, User user)
        {
            var use_r = _context.Users.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (use_r == null) return BadRequest("Usuário não encontrado!");

            _context.Update(user);
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(a => a.Id == id);
            if (user == null) return BadRequest("Usuário não encontrado!"); 

            _context.Remove(user);
            _context.SaveChanges();
            return Ok();
        }


    }
}

