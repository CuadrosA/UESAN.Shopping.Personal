using UESAN.Shopping.Core.DTOs;

namespace UESAN.Shopping.Core.Interfaces
{
    public interface IProductDetailService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<ProductDetailGeneralDTO>> GetAll();
        Task<ProductDetailDTO> GetById(int id);
        Task<bool> Insert(ProductDetailInsertDTO productDetailInsertDTO);
        Task<bool> Update(ProductDetailUpdateDTO productDetailUpdateDTO);
    }
}