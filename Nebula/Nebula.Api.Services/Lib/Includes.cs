using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;
namespace NebulaNS.Api.Services
{

    public class ValidationError
    {
        public ValidationError(string errorCode, string errorMessage, string propertyName)
        {
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
            this.PropertyName = propertyName;
        }

        public string ErrorMessage { get; set; } = string.Empty;

        public string PropertyName { get; set; } = string.Empty;

        public string ErrorCode { get; set; } = string.Empty;
    }

    public class CreateResponse<T> : ActionResponse
    {
        public T Record { get; private set; }
        public CreateResponse(FluentValidation.Results.ValidationResult result)
            : base(result)
        {
        }

        public void SetRecord(T record)
        {
            this.Record = record;
        }
    }


    public class ActionResponse
    {
        public bool Success { get; private set; }

        public List<ValidationError> ValidationErrors { get; private set; } = new List<ValidationError>();

        private FluentValidation.Results.ValidationResult result;

        public ActionResponse(ValidationResult result)
        {
            this.Success = result.IsValid;
            foreach (ValidationFailure error in result.Errors)
            {
                this.ValidationErrors.Add(new ValidationError(error.ErrorCode, error.ErrorMessage, error.PropertyName));
            }
        }
    }
}