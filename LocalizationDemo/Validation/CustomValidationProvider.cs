using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizationDemo.Validation
{
    public class CustomValidationProvider : IValidationMetadataProvider
    {
        Dictionary<Type, string> _errorMessages;

        public CustomValidationProvider()
        {
            _errorMessages = new Dictionary<Type, string>
            {
                {typeof(RequiredAttribute), "RequiredError" },
                {typeof(MaxLengthAttribute), "MaxLengthError" }
            };
        }
        public void CreateValidationMetadata(ValidationMetadataProviderContext context)
        {
            foreach (var attribute in context.Attributes)
            {
                if (attribute is ValidationAttribute validationAttribute)
                {
                    Type type = attribute.GetType();
                    if (_errorMessages.TryGetValue(type, out string key))
                    {
                        validationAttribute.ErrorMessage = key;
                    }
                }
            }
        }
    }
}
