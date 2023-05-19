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
    public class ProductDetailService : IProductDetailService
    {
        private readonly IProductDetailRepository _productDetailRepository;

        public ProductDetailService(IProductDetailRepository productDetailRepository)
        {
            _productDetailRepository = productDetailRepository;
        }

        public async Task<IEnumerable<ProductDetailGeneralDTO>> GetAll()
        {
            var productDetails = await _productDetailRepository.GetAll();
            var productDetailsDTO = new List<ProductDetailGeneralDTO>();
            foreach (var productDetail in productDetails)
            {
                var productDetailDTO = new ProductDetailGeneralDTO();
                productDetailDTO.Id = productDetail.Id;
                productDetailDTO.ProductId = productDetail.ProductId;
                productDetailDTO.ImageUrl = productDetail.ImageUrl;
                productDetailDTO.IsActive = productDetail.IsActive;
                productDetailDTO.CreatedAt = productDetail.CreatedAt;
                productDetailsDTO.Add(productDetailDTO);
            }
            return productDetailsDTO;
        }

        public async Task<ProductDetailDTO> GetById(int id)
        {
            var productDetail = await _productDetailRepository.GetById(id);
            if (productDetail == null)
                return null;

            var productDetailDTO = new ProductDetailDTO()
            {
                Id = productDetail.Id,
                ProductId = productDetail.ProductId,
                ImageUrl = productDetail.ImageUrl,
                IsActive = productDetail.IsActive,
                CreatedAt = productDetail.CreatedAt,
            };
            return productDetailDTO;
        }

        public async Task<bool> Insert(ProductDetailInsertDTO productDetailInsertDTO)
        {
            var productDetail = new ProductDetail();
            productDetail.ProductId = productDetailInsertDTO.ProductId;
            productDetail.ImageUrl = productDetailInsertDTO.ImageUrl;
            productDetail.IsActive = productDetailInsertDTO.IsActive;
            productDetail.CreatedAt = productDetailInsertDTO.CreatedAt;

            var result = await _productDetailRepository.Insert(productDetail);
            return result;
        }

        public async Task<bool> Update(ProductDetailUpdateDTO productDetailUpdateDTO)
        {
            var productDetail = await _productDetailRepository.GetById(productDetailUpdateDTO.Id);
            if (productDetail == null)
                return false;
            productDetail.ProductId = productDetailUpdateDTO.ProductId;
            productDetail.ImageUrl = productDetailUpdateDTO.ImageUrl;
            productDetail.IsActive = productDetailUpdateDTO.IsActive;
            productDetail.CreatedAt = productDetailUpdateDTO.CreatedAt;

            var result = await _productDetailRepository.Update(productDetail);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var productDetail = await _productDetailRepository.GetById(id);
            if (productDetail == null)
                return false;

            productDetail.IsActive = false;
            var result = await _productDetailRepository.Delete(id);
            return result;
        }




    }
}
