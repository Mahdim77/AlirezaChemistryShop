using CustomFramework.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.ProductCategory
{
    public class CreateProductCategory
    {
        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
        [MaxLength(100, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string Name { get; set; }

        [MaxSizeFileVallidation(4 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSizeMessage)]
        [FileExtensionValidator(new string[] {"jpeg", "jpg", "png", "gif"} , ErrorMessage = ValidationMessages.FileExtensionValidation)]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
        [MaxLength(120, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string ImageAlt { get; set; }
        
        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
        [MaxLength(80, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string ImageTitle { get; set; }

        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
        [MaxLength(1000, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string Description { get; set; }

        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string MetaDescription { get; set; }

        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
        [MaxLength(300, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string Keywords { get; set; }

        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
        [MaxLength(150, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string Slug { get; set; }
    }
}
