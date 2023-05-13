using UESAN.Shopping.Core.Entities;

namespace UESAN.Shopping.Core.Interfaces
{
    public interface IFavoriteRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Favorite>> GetAll();
        Task<Favorite> GetById(int id);
        Task<bool> Insert(Favorite favorite);
        Task<bool> Update(Favorite favorite);
    }
}