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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserService userService, IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDescriptionDTO>> GetAll()
        {
            var users = await _userRepository.GetAll();
            var usersDTO = new List<UserDescriptionDTO>();
            foreach (var user in users)
            {
                var userDTO = new UserDescriptionDTO();
                userDTO.Id = user.Id;
                userDTO.FirstName = user.FirstName;
                userDTO.LastName = user.LastName;
                userDTO.DateOfBirth = user.DateOfBirth;
                userDTO.Country = user.Country;
                userDTO.Address = user.Address;
                userDTO.Email = user.Email;
                userDTO.Password = user.Password;
                userDTO.IsActive = user.IsActive;
                userDTO.Type = user.Type;
                usersDTO.Add(userDTO);
            }
            return usersDTO;
        }

        public async Task<UserDTO> GetById(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
                return null;

            var userDTO = new UserDTO()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Country = user.Country,
                Address = user.Address,
                Email = user.Email,
                Password = user.Password,
                IsActive = user.IsActive,
                Type = user.Type
            };
            return userDTO;
        }

        public async Task<bool> Insert(UserInsertDTO userInsertDTO)
        {
            var user = new User();
            user.FirstName = userInsertDTO.FirstName;
            user.LastName = userInsertDTO.LastName;
            user.DateOfBirth = userInsertDTO.DateOfBirth;
            user.Country = userInsertDTO.Country;
            user.Address = userInsertDTO.Address;
            user.Email = userInsertDTO.Email;
            user.Password = userInsertDTO.Password;
            user.IsActive = userInsertDTO.IsActive;
            user.Type = userInsertDTO.Type;

            var result = await _userRepository.Insert(user);
            return result;
        }

        public async Task<bool> Update(UserUpdateDTO userUpdateDTO)
        {
            var user = await _userRepository.GetById(userUpdateDTO.Id);
            if (user != null)
                return false;
            user.FirstName = userUpdateDTO.FirstName;
            user.LastName = userUpdateDTO.LastName;
            user.DateOfBirth = userUpdateDTO.DateOfBirth;
            user.Country = userUpdateDTO.Country;
            user.Address = userUpdateDTO.Address;
            user.Email = userUpdateDTO.Email;
            user.Password = userUpdateDTO.Password;
            user.IsActive = userUpdateDTO.IsActive;
            user.Type = userUpdateDTO.Type;

            var result = await _userRepository.Update(user);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user != null) 
                return false;

            var result = await _userRepository.Delete(id);
            return result;
        }
        
    }
}
