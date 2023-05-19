using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Shopping.Core.Entities;

namespace UESAN.Shopping.Core.DTOs
{
    public class ProductDetailDTO
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string? ImageUrl { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class ProductDetailGeneralDTO
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string? ImageUrl { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public class ProductDetailInsertDTO
    {
        public int? ProductId { get; set; }
        public string? ImageUrl { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public class ProductDetailUpdateDTO
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string? ImageUrl { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
