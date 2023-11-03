using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class UserDTO
    {
        public int IdUser { get; set; }

        [Required(ErrorMessage = "Please enter full name")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        public string? Mail { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Please enter password confirm")]
        public string? PasswordConfirm { get; set; }

        public string? Role { get; set; }

    }
}

