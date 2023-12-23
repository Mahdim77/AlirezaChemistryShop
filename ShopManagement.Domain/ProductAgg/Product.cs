using CustomFramework.Domain;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product : EntityBase
    {
        public string Name { get; private set; }
        public string Image { get; private set; }
        public string ImageAlt { get; private set; }
        public string ImageTitle { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Keywords { get; private set; }
        public string Slug { get; private set; }
        public string MetaDescription { get; private set; }
        public string CasNumber { get; private set; }
        public string Formula { get; private set; }
        public long ProductCategoryId { get; private set; }
        public ProductCategory Category { get; private set; }
        public string MeasurementUnit { get; private set; }
        
    }
}
