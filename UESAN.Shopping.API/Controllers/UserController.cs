using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using UESAN.Shopping.Core.DTOs;
using UESAN.Shopping.Core.Entities;
using UESAN.Shopping.Core.Interfaces;

namespace UESAN.Shopping.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user = await _userService.GetAll();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetById(id);
            if (user == null) 
                return NotFound();

            return Ok(user);
        }

        [HttpGet("{id, String}")]
        public async Task<IActionResult> Prove(int id, string password)
        {
            bool user = await _userService.Prove(id,password ) ;
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(UserInsertDTO user)
        {
            var result = await _userService.Insert(user);
            if (!result)
                return BadRequest();
            return NoContent();
        }
                  
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserUpdateDTO user)
        {
            if (id != user.Id)
                return NotFound();

            var result = await _userService.Update(user);
            if (!result)
                return BadRequest();
            
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.Delete(id);
            if(!result)
                return BadRequest();

            return NoContent();
        }

    }
}
