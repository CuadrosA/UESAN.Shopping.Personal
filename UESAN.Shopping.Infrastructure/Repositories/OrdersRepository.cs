using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Shopping.Core.Entities;
using UESAN.Shopping.Core.Interfaces;
using UESAN.Shopping.Infrastructure.Data;

namespace UESAN.Shopping.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly StoreDbContext _dbContext;

        public OrdersRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Orders>> GetAll()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<Orders> GetById(int id)
        {
            return await _dbContext.Orders.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Orders orders)
        {
            await _dbContext.Orders.AddAsync(orders);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(Orders orders)
        {
            _dbContext.Orders.Update(orders);
            int rows = _dbContext.SaveChanges();
            return rows > 0;
        }
    }
}
