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
    public class ProductDetailRepository : IProductDetailRepository
    {
        private readonly StoreDbContext _dbContext;

        public ProductDetailRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductDetail>> GetAll()
        {
            return await _dbContext
                .ProductDetail
                .Where(x => x.IsActive == true)
                .ToListAsync();
        }

        public async Task<ProductDetail> GetById(int id)
        {
            return await _dbContext
                .ProductDetail
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(ProductDetail productDetail)
        {
            await _dbContext.ProductDetail.AddAsync(productDetail);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(ProductDetail productDetail)
        {
            _dbContext.ProductDetail.Update(productDetail);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var findProductDetail = await _dbContext
                                        .ProductDetail
                                        .Where(x => x.Id == id)
                                        .FirstOrDefaultAsync();
            if (findProductDetail == null)
                return false;

            findProductDetail.IsActive = false;
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

    }
}
