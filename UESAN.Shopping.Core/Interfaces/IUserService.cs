using UESAN.Shopping.Core.DTOs;

namespace UESAN.Shopping.Core.Interfaces
{
    public interface IUserService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<UserDescriptionDTO>> GetAll();
        Task<UserDTO> GetById(int id);
        Task<bool> Insert(UserInsertDTO userInsertDTO);
        Task<bool> Update(UserUpdateDTO userUpdateDTO);
        Task<bool> Prove(int id, string password);
    }
}
