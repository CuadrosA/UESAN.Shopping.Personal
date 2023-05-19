using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Shopping.Core.DTOs;
using UESAN.Shopping.Core.Entities;
using UESAN.Shopping.Core.Interfaces;

namespace UESAN.Shopping.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(ICategoryService categoryService, IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDescriptionDTO>> GetAll()
        {
            var products = await _productRepository.GetAll();
            var productsDTO = new List<ProductDescriptionDTO>();
            foreach (var product in products)
            {
                var productDTO = new ProductDescriptionDTO();
                productDTO.Id = product.Id;
                productDTO.Description = product.Description;
                productDTO.ImageUrl = product.ImageUrl;
                productDTO.Stock = product.Stock;
                productDTO.Price = product.Price;
                productDTO.Discount = product.Discount;
                productDTO.CategoryId = product.CategoryId;
                productDTO.IsActive = product.IsActive;
                productsDTO.Add(productDTO);
            }
            return productsDTO;
        }

        

        public async Task<ProductDTO> GetById(int id)
        { 
            var product = await _productRepository.GetById(id);
            if (product == null)
                return null;

            var productDTO = new ProductDTO()
            {
                Id = product.Id,
                Description = product.Description,
                Discount = product.Discount,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId,
            };
            return productDTO;
        }

        public async Task<bool> Insert(ProductInsertDTO productInsertDTO)
        {
            var product = new Product();
            product.Description = productInsertDTO.Description;
            product.ImageUrl = productInsertDTO.ImageUrl;
            product.Stock = productInsertDTO.Stock;
            product.Price = productInsertDTO.Price;
            product.Discount = productInsertDTO.Discount;
            product.IsActive = productInsertDTO.IsActive;
            
            var result = await _productRepository.Insert(product);
            return result;
        }

        public async Task<bool> Update(ProductUpdateDTO productUpdateDTO)
        {
            var product = await _productRepository.GetById(productUpdateDTO.Id);
            if (product == null) 
                return false;
            product.Description = productUpdateDTO.Description;
            product.ImageUrl = productUpdateDTO.ImageUrl;
            product.Stock = productUpdateDTO.Stock;
            product.Price = productUpdateDTO.Price;
            product.Discount = productUpdateDTO.Discount;
            product.CategoryId= productUpdateDTO.CategoryId; 

            var result = await _productRepository.Update(product);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null)
                return false;

            var result = await _productRepository.Delete(id);
            return result;
        }

    }
}
