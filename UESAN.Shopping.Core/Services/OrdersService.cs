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
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        public OrdersService(IUserService userService, IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }
        public async Task<IEnumerable<OrdersGeneralDTO>> GetAll()
        {
            var orderss = await _ordersRepository.GetAll();
            var ordersDTO = new List<OrdersGeneralDTO>();
            foreach (var orders in orderss)
            {
                var ordersGeneralDTO = new OrdersGeneralDTO();
                ordersGeneralDTO.Id = orders.Id;
                ordersGeneralDTO.CreatedAt = orders.CreatedAt;
                ordersGeneralDTO.UserId = orders.UserId;
                ordersGeneralDTO.Status = orders.Status;
                ordersGeneralDTO.TotalAmount = orders.TotalAmount; //Modificar
                ordersDTO.Add(ordersGeneralDTO);
            }
            return ordersDTO;
        }

        public async Task<OrdersDTO> GetById(int id)
        {
            var orders = await _ordersRepository.GetById(id);
            if (orders == null)
                return null;

            var ordersDTO = new OrdersDTO();
            {
                ordersDTO.Id = orders.Id;
                ordersDTO.CreatedAt = orders.CreatedAt;
                ordersDTO.UserId = orders.UserId;
                ordersDTO.Status = orders.Status;
                ordersDTO.TotalAmount = orders.TotalAmount;
            }
            return ordersDTO;
        }

        public async Task<bool> Insert(OrdersInsertDTO ordersInsertDTO)
        {
            var orders = new Orders();
            orders.CreatedAt = ordersInsertDTO.CreatedAt;
            orders.UserId = ordersInsertDTO.UserId;
            orders.Status = ordersInsertDTO.Status;
            orders.TotalAmount = ordersInsertDTO.TotalAmount;

            var result = await _ordersRepository.Insert(orders);
            return result;
        }
        public async Task<bool> Update(OrdersUpdateDTO ordersUpdateDTO)
        {
            var orders = await _ordersRepository.GetById(ordersUpdateDTO.Id);
            if (orders == null)
                return false;
            orders.CreatedAt = ordersUpdateDTO.CreatedAt;
            orders.UserId = ordersUpdateDTO.UserId;
            orders.Status = ordersUpdateDTO.Status;

            var result = await _ordersRepository.Update(orders);
            return result;
        }
    }
}
