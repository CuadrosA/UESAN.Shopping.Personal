using Microsoft.AspNetCore.Mvc;
using UESAN.Shopping.Core.DTOs;
using UESAN.Shopping.Core.Interfaces;
using UESAN.Shopping.Core.Services;

namespace UESAN.Shopping.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productDetails = await _productDetailService.GetAll();
            return Ok(productDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productDetails = await _productDetailService.GetById(id);
            if (productDetails == null)
                return NotFound();

            return Ok(productDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(ProductDetailInsertDTO productDetail)
        {
            var result = await _productDetailService.Insert(productDetail);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductDetailUpdateDTO productDetail)
        {
            if (id != productDetail.Id)
                return NotFound();

            var result = await _productDetailService.Update(productDetail);
            if (!result)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productDetailService.Delete(id);
            if (!result)
                return BadRequest();

            return NoContent();
        }
    }
}
