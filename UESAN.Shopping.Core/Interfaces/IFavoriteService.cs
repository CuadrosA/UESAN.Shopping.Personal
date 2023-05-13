using UESAN.Shopping.Core.DTOs;

namespace UESAN.Shopping.Core.Interfaces
{
    public interface IFavoriteService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<FavoriteDescriptionDTO>> GetAll();
        Task<FavoriteDTO> GetById(int id);
        Task<bool> Insert(FavoriteInsertDTO favoriteInsertDTO);
        Task<bool> Update(FavoriteUpdateDTO favoriteUpdateDTO);
    }
}