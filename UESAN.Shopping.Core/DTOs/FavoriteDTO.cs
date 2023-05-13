using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Shopping.Core.DTOs
{
    public class FavoriteDTO
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class FavoriteDescriptionDTO
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class FavoriteInsertDTO
    {
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class FavoriteUpdateDTO
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
