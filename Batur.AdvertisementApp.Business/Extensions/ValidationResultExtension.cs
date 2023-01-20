using Batur.AdvertisementApp.Common;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batur.AdvertisementApp.Business.Extensions
{
    public static class ValidationResultExtension
    {
        public static List<CustomValidationError> ConvertToValidationError(this ValidationResult validationResult)
        {
            List<CustomValidationError> customErrors = new();
            foreach (var item in validationResult.Errors)
            {
                customErrors.Add(new()
                {
                    ErrorMessage = item.ErrorMessage,
                    PropertyName = item.PropertyName,
                });
            }
            return customErrors;
        }
    }
}
