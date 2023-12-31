using CustomFramework.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Product
{
    public class CreateProduct
    {
        public string Name { get; set; }
        public IFormFile? Image { get; set; }
        public string ImageAlt { get; set; }
        public string ImageTitle { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Slug { get; set; }
        public string CategorySlug { get; set; }
        public string MetaDescription { get; set; }
        public string CasNumber { get; set; }
        public string Formula { get; set; }
        public long ProductCategoryId { get; set; }
        public string MeasurementUnit { get; set; }

        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
        public List<long> ProductCompanies { get; set; }
    }
}
