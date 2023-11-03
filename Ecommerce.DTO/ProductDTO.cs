using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class ProductDTO
    {
        public int IdProduct { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter description")]
        public string? Description { get; set; }

        public int? IdCategory { get; set; }

        [Required(ErrorMessage = "Please enter price")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Please enter offer price")]
        public decimal? PriceOffer { get; set; }

        [Required(ErrorMessage = "Please enter amount")]
        public int? Amount { get; set; }

        [Required(ErrorMessage = "Please enter image")]
        public string? Image { get; set; }

        public DateTime? CreationDate { get; set; }

        public virtual CategoryDTO? IdCategoryNavigation { get; set; }
    }
}
