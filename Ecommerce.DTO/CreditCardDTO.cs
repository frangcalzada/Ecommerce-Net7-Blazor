using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class CreditCardDTO
    {
        [Required(ErrorMessage = "Please enter full name")]
        public string? Fullname { get; set; }

        [Required(ErrorMessage = "Please enter card number")]
        public string? CardNumber { get; set; }

        [Required(ErrorMessage = "Please enter expiration date")]
        public string? ExpirationDate { get; set; }

        [Required(ErrorMessage = "Please enter CCV")]
        public string? CCV { get; set; }
    }
}
