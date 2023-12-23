using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomFramework.Application
{
    public class MaxSizeFileVallidationAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly int _MaxSize;

        public MaxSizeFileVallidationAttribute(int maxSize)
        {
            _MaxSize = maxSize;
        }


        public override bool IsValid(object value)
        {
            var file = value as IFormFile;
            if (file == null)
            {
                return true;
            }

            return file.Length < _MaxSize;
        }


        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-maxFileSize", ErrorMessage);
        }
    }
}
