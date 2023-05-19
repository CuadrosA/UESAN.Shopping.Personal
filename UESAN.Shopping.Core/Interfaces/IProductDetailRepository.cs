using UESAN.Shopping.Core.Entities;

namespace UESAN.Shopping.Core.Interfaces
{
    public interface IProductDetailRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<ProductDetail>> GetAll();
        Task<ProductDetail> GetById(int id);
        Task<bool> Insert(ProductDetail productDetail);
        Task<bool> Update(ProductDetail productDetail);
    }
}