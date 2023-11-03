using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    //Generic so that we can respond under any model, like Sales, Product..
    public class ResponseDTO<T>
    {
        public T? Result { get; set; }
        public bool IsCorrect { get; set; }
        public string? Message { get; set; }
    }
}
