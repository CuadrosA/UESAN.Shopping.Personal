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
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task<IEnumerable<FavoriteDescriptionDTO>> GetAll()
        {
            var favorites = await _favoriteRepository.GetAll();
            var favoritesDTO = new List<FavoriteDescriptionDTO>();

            foreach (var favorite in favorites)
            {
                var favoriteDTO = new FavoriteDescriptionDTO();
                favoriteDTO.Id = favorite.Id;
                favoriteDTO.UserId = favorite.UserId;
                favoriteDTO.ProductId = favorite.ProductId;
                favoriteDTO.CreatedAt = favorite.CreatedAt;
                favoritesDTO.Add(favoriteDTO);
            }
            return favoritesDTO;
        }

        public async Task<FavoriteDTO> GetById(int id)
        {
            var favorite = await _favoriteRepository.GetById(id);
            var favoriteDTO = new FavoriteDTO();
            favoriteDTO.UserId = favorite.UserId;
            favorite.Id = favorite.Id;
            favorite.ProductId = favorite.ProductId;
            favorite.CreatedAt = favorite.CreatedAt;
            return favoriteDTO;
        }

        public async Task<bool> Insert(FavoriteInsertDTO favoriteInsertDTO)
        {
            var favorite = new Favorite();
            favorite.UserId = favoriteInsertDTO.UserId;
            favorite.ProductId = favoriteInsertDTO.ProductId;
            favorite.CreatedAt = favoriteInsertDTO.CreatedAt;

            var result = await _favoriteRepository.Insert(favorite);
            return result;
        }

        public async Task<bool> Update(FavoriteUpdateDTO favoriteUpdateDTO)
        {
            var favorite = await _favoriteRepository.GetById(favoriteUpdateDTO.Id);
            if (favorite != null)
                return false;
            favorite.UserId = favoriteUpdateDTO.UserId;
            favorite.ProductId = favoriteUpdateDTO.ProductId;
            favorite.CreatedAt = favoriteUpdateDTO.CreatedAt;

            var result = await _favoriteRepository.Update(favorite);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var favorite = await _favoriteRepository.GetById(id);
            if (favorite != null)
                return false;

            var result = await _favoriteRepository.Delete(id);
            return result;
        }

    }
}
