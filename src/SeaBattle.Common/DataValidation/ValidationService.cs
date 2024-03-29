﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SeaBattle.Common.DataValidation
{
    public class ValidationService : IValidationService
    {
        private readonly IModelValidator[] _validators;

        public ValidationService(IEnumerable<IModelValidator> validators)
        {
            _validators = validators?.ToArray() ?? Array.Empty<IModelValidator>();
        }

        public ValidationData Validate<T>(T model)
        {
            string[] errors = _validators
                .Where(v => v.CanValiate(model))
                .Select(v => v.Validate(model))
                .Where(r => !r.Success)
                .SelectMany(r => r.Errors)
                .Distinct()
                .ToArray();

            return new ValidationData(!(errors.Length > 0), errors);
        }
    }
}
