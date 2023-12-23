using CustomFramework.Domain;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public class ProductCategory : EntityBase
    {
        public string Name { get; private set; }
        public string Image { get; private set; }
        public string ImageAlt { get; private set; }
        public string ImageTitle { get; private set; }
        public string Description { get; private set; }
        public string MetaDescription { get; private set; }
        public string Keywords { get; private set; }
        public string Slug { get; private set; }

        public List<Product> Products { get; private set; }

        public ProductCategory(string name, string image, string imageAlt, string imageTitle, string description, string metaDescription, string keywords, string slug)
        {
            Name = name;
            Image = image;
            ImageAlt = imageAlt;
            ImageTitle = imageTitle;
            Description = description;
            MetaDescription = metaDescription;
            Keywords = keywords;
            Slug = slug;
        }
        public void Edit(string name, string image, string imageAlt, string imageTitle, string description, string metaDescription, string keywords, string slug)
        {
            Name = name;
            if (!string.IsNullOrEmpty(image))
            {
                Image = image;
            }
            ImageAlt = imageAlt;
            ImageTitle = imageTitle;
            Description = description;
            MetaDescription = metaDescription;
            Keywords = keywords;
            Slug = slug;
        }
    }
}
