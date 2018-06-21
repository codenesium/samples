using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

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
                public virtual T Record { get; private set; }

                public CreateResponse(FluentValidation.Results.ValidationResult result)
                        : base(result)
                {
                }

                public virtual void SetRecord(T record)
                {
                        this.Record = record;
                }
        }

        public interface IActionResponse
        {
                bool Success { get; }

                List<ValidationError> ValidationErrors { get; }
        }

        public class ActionResponse : IActionResponse
        {
                public virtual bool Success { get; private set; }

                public virtual List<ValidationError> ValidationErrors { get; private set; } = new List<ValidationError>();

                public ActionResponse()
                {
                }

                public ActionResponse(ValidationResult result)
                {
                        this.Success = result.IsValid;
                        foreach (ValidationFailure error in result.Errors)
                        {
                                this.ValidationErrors.Add(new ValidationError(error.ErrorCode, error.ErrorMessage, error.PropertyName));
                        }
                }
        }

        public abstract class AbstractService
        {
        }

        public abstract class AbstractBusinessObject
        {
        }
}

/*<Codenesium>
    <Hash>577c9e3f9ef55cfb27ca94bfab5ff40a</Hash>
</Codenesium>*/