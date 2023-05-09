using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Shopping.Core.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public String? Country { get; set; }
        public String? Address { get; set; }
        public string? Email { get; set; }
        public String? Password { get; set; }
        public bool? IsActive { get; set; }
        public string? Type { get; set; }
    }

    public class UserInsertDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public String? Country { get; set; }
        public String? Address { get; set; }
        public string? Email { get; set; }
        public String? Password { get; set; }
        public bool? IsActive { get; set; }
        public string? Type { get; set; }
    }

    public class UserDescriptionDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public String? Country { get; set; }
        public String? Address { get; set; }
        public string? Email { get; set; }
        public String? Password { get; set; }
        public bool? IsActive { get; set; }
        public string? Type { get; set; }
    }

    public class UserUpdateDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public String? Country { get; set; }
        public String? Address { get; set; }
        public string? Email { get; set; }
        public String? Password { get; set; }
        public bool? IsActive { get; set; }
        public string? Type { get; set; }
    }



}
