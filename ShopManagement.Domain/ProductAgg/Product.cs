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
        public string? ShortDescription { get; private set; }
        public string? Description { get; private set; }
        public string Keywords { get; private set; }
        public string Slug { get; private set; }
        public string MetaDescription { get; private set; }
        public string CasNumber { get; private set; }
        public string Formula { get; private set; }
        public bool? IsInStock { get; private set; }
        public bool IsDeleted { get; private set; }
        public long ProductCategoryId { get; private set; }
        public ProductCategory Category { get; private set; }
        public string MeasurementUnit { get; private set; }
        public List<ProductCompany> ProductCompanies { get; private set; }

        public Product(string name, string image, string imageAlt, string imageTitle, string shortDescription, string description, string keywords, string slug, string metaDescription, string casNumber, string formula, long productCategoryId, string measurementUnit)
        {
            Name = name;
            Image = image;
            ImageAlt = imageAlt;
            ImageTitle = imageTitle;
            ShortDescription = shortDescription;
            Description = description;
            Keywords = keywords;
            Slug = slug;
            MetaDescription = metaDescription;
            CasNumber = casNumber;
            Formula = formula;
            ProductCategoryId = productCategoryId;
            MeasurementUnit = measurementUnit;
            IsDeleted = false;
        }
        public void Edit(string name, string image, string imageAlt, string imageTitle, string shortDescription, string description, string keywords, string slug, string metaDescription, string casNumber, string formula, long productCategoryId, string measurementUnit)
        {
            Name = name;
            Image = image;
            ImageAlt = imageAlt;
            ImageTitle = imageTitle;
            ShortDescription = shortDescription;
            Description = description;
            Keywords = keywords;
            Slug = slug;
            MetaDescription = metaDescription;
            CasNumber = casNumber;
            Formula = formula;
            ProductCategoryId = productCategoryId;
            MeasurementUnit = measurementUnit;
        }
        public void Restore()
        {
            IsDeleted = false;
        }
        public void Delete()
        {
            IsDeleted= true;
        }
        public void Available()
        {
            IsInStock = true;
        }
        public void NotAvailable()
        {
            IsInStock= false;
        }
    }
}
