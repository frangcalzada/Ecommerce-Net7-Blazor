using System;
using System.Collections.Generic;

namespace Ecommerce.Model;

public partial class Product
{
    public int IdProduct { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? IdCategory { get; set; }

    public decimal? Price { get; set; }

    public decimal? PriceOffer { get; set; }

    public int? Amount { get; set; }

    public string? Image { get; set; }

    public DateTime? CreationDate { get; set; }

    public virtual ICollection<DetailSale> DetailSales { get; set; } = new List<DetailSale>();

    public virtual Category? IdCategoryNavigation { get; set; }
}
