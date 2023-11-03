using System;
using System.Collections.Generic;

namespace Ecommerce.Model;

public partial class Sale
{
    public int IdSale { get; set; }

    public int? IdUser { get; set; }

    public decimal? Total { get; set; }

    public DateTime? CreationDate { get; set; }

    public virtual ICollection<DetailSale> DetailSales { get; set; } = new List<DetailSale>();

    public virtual User? IdUserNavigation { get; set; }
}
