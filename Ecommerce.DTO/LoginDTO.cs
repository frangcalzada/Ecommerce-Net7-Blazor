using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Please enter email")]
        public string? Mail { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        public string? Password { get; set; }
    }
}
