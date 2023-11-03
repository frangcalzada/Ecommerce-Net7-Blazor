using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class DashboardDTO
    {
        public string? TotalIncome { get; set; }
        public int TotalSales { get; set; }
        public int TotalClients { get; set; }
        public int TotalProducts { get; set; }
    }
}
