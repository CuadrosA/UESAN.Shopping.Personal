using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Shopping.Core.DTOs;

namespace UESAN.Shopping.Core.Interfaces
{
    public interface IProductService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<ProductDescriptionDTO>> GetAll();
        Task<ProductDTO> GetById(int id);
        Task<bool> Insert(ProductInsertDTO productInsertDTO);
        //Falta ver qué se hace con esta última línea
        Task<bool> Update(ProductUpdateDTO productUpdateDTO);

    }
}
