using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using ValidationResult = FluentValidation.Results.ValidationResult;


namespace HRLeaveManagement.Application.Excpetions
{
    public class BadRequestExcpetion : Exception
    {
        public BadRequestExcpetion(string message) : base(message) { }
        public BadRequestExcpetion(string message, ValidationResult validationResult)
             : base(message)
        {
            ValidationErrors = new List<string>();

            foreach (var error in validationResult.Errors)
            {
                ValidationErrors.Add(error.ErrorMessage);
            }
        }

        public List<string> ValidationErrors { get; set; }

    }
}
