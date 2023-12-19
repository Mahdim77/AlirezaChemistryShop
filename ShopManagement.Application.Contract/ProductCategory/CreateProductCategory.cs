using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.ProductCategory
{
    public class CreateProductCategory
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string ImageAlt { get; set; }
        public string ImageTitle { get; set; }
        public string Description { get; set; }
        public string MetaDescription { get; set; }
        public string Keywords { get; set; }

        public string Slug { get; set; }
    }
}
