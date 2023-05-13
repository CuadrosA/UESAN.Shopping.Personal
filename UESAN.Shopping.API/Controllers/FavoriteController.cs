using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UESAN.Shopping.Core.DTOs;
using UESAN.Shopping.Core.Entities;
using UESAN.Shopping.Core.Interfaces;


namespace UESAN.Shopping.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var favorites = await _favoriteService.GetAll();
            return Ok(favorites);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var favorite = await _favoriteService.GetById(id);
            if (favorite == null) 
                return NotFound();

            return Ok(favorite);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(FavoriteInsertDTO favorite)
        {
            var result = await _favoriteService.Insert(favorite);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, FavoriteUpdateDTO favorite)
        {
            if(id != favorite.Id)
                return NotFound();

            var result = await _favoriteService.Update(favorite);
            if (!result)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _favoriteService.Delete(id);
            if (!result)
                return BadRequest();

            return NoContent();
        }

    }
}
