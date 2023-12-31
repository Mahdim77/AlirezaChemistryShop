﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomFramework.Application
{
    
        public class FileExtensionValidatorAttribute : ValidationAttribute, IClientModelValidator
        {
            private readonly string[] _AllowExtensions;

            public FileExtensionValidatorAttribute(string[] allowExtentions)
            {
                _AllowExtensions = allowExtentions;
            }

            public override bool IsValid(object? value)
            {
                var file = value as IFormFile;
                if (file == null)
                {
                    return true;
                }

                var extention = Path.GetExtension(file.FileName);

                return _AllowExtensions.Contains(extention);

            }

            public void AddValidation(ClientModelValidationContext context)
            {

                context.Attributes.Add("data-val-allowsExtentions", ErrorMessage);
            }

        }
    }

