using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace StudioResourceManagerNS.Api.Contracts
{
    public class ValidationError
    {
        public ValidationError(string errorCode, string errorMessage, string propertyName)
        {
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
            this.PropertyName = propertyName;
        }

		[JsonProperty]
        public string ErrorMessage { get; set; } = string.Empty;

	    [JsonProperty]
        public string PropertyName { get; set; } = string.Empty;

		[JsonProperty]
        public string ErrorCode { get; set; } = string.Empty;
    }

    public class CreateResponse<T> : ActionResponse
    {
	    [JsonProperty]
        public virtual T Record { get; private set; }

        public CreateResponse(FluentValidation.Results.ValidationResult result)
                : base(result)
        {
        }

		public CreateResponse()
		{
		}

        public virtual void SetRecord(T record)
        {
            this.Record = record;
			this.Success = true;
        }
    }
	
    public class UpdateResponse<T> : ActionResponse
    {
	    [JsonProperty]
        public virtual T Record { get; private set; }

        public UpdateResponse(FluentValidation.Results.ValidationResult result)
                : base(result)
        {
        }

		public UpdateResponse(T record)
		{
			this.SetRecord(record);
			this.Success = true;
		}

		public UpdateResponse()
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
		[JsonProperty]
        public virtual bool Success { get; protected set; }

		[JsonProperty]
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
}