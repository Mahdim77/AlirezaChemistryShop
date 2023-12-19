using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.ProductCategory
{
    public class ProductCategoryViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string CreationDate { get; set; }

        public int ProductCount { get; set; }
    }
}
