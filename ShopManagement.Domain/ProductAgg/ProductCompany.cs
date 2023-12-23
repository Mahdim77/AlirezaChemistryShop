using ShopManagement.Domain.CompanyAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductAgg
{
    public class ProductCompany
    {
        public long ProductId { get; private set; }
        public Product Product { get; private set; }
        public long CompanyId { get; private set; }
        public Company Company { get; private set; }
    }
}
