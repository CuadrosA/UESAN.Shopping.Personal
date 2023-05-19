using UESAN.Shopping.Core.Entities;

namespace UESAN.Shopping.Core.Interfaces
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Orders>> GetAll();
        Task<Orders> GetById(int id);
        Task<bool> Insert(Orders orders);
        Task<bool> Update(Orders orders);
    }
}