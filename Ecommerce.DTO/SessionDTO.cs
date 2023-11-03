using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class SessionDTO
    {
        public int IdUser { get; set; }

        public string? FullName { get; set; }

        public string? Mail { get; set; }

        public string? Role { get; set; }
    }
}
