using UESAN.Shopping.Core.DTOs;

namespace UESAN.Shopping.Core.Interfaces
{
    public interface IOrdersService
    {
        Task<IEnumerable<OrdersGeneralDTO>> GetAll();
        Task<OrdersDTO> GetById(int id);
        Task<bool> Insert(OrdersInsertDTO ordersInsertDTO);
        Task<bool> Update(OrdersUpdateDTO ordersUpdateDTO);
    }
}