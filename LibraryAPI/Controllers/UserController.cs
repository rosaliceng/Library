using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api /[controller]")]
    public class UserController : ControllerBase
    {
        public UserController() { }

        [HttpGet]
        
        public IActionResult Get()
        {
            return Ok("Users: Rosa, Artur, José");
        }


    }
}







