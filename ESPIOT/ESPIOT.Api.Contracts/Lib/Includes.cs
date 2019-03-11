using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESPIOTNS.Api.Contracts
{
	public class ValidationErrorCodes
	{
		public const string ViolatesShouldNotBeNullRule = "ViolatesShouldNotBeNullRule";
		public const string ViolatesLengthRule = "ViolatesLengthRule";
		public const string ViolatesUniqueConstraintRule = "ViolatesUniqueConstraintRule";
		public const string ViolatesForeignKeyConstraintRule = "ViolatesForeignKeyConstraintRule";
	}

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

		public CreateResponse()
		{
		}

		public CreateResponse(T record)
		{
			this.SetRecord(record);
			this.Success = true;
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

		public UpdateResponse()
		{
		}

		public UpdateResponse(T record)
		{
			this.SetRecord(record);
			this.Success = true;
		}

        public virtual void SetRecord(T record)
        {
            this.Record = record;
        }
    }

	public class AuthResponse : ActionResponse
	{
		[JsonProperty]
		public virtual string Token { get; private set; }

		[JsonProperty]
		public virtual string Link { get; private set; }

		[JsonProperty]
		public virtual string Message { get; private set; }

		[JsonProperty]
		public virtual string ErrorCode { get; private set; }

		public AuthResponse()
		{
		}

		public virtual void SetMessage(string message)
		{
			this.Message = message;
		}

		public virtual void SetLink(string link)
		{
			this.Link = link;
		}

		public virtual void SetToken(string token)
		{
			this.Token = token;
		}

		public virtual void SetErrorCode(string errorCode)
		{
			this.ErrorCode = errorCode;
		}
	}

	public interface IActionResponse
    {
        bool Success { get; set; }

        List<ValidationError> ValidationErrors { get; }
    }

    public class ActionResponse : IActionResponse
    {
		[JsonProperty]
        public virtual bool Success { get; set; }

		[JsonProperty]
        public virtual List<ValidationError> ValidationErrors { get; private set; } = new List<ValidationError>();

		public void AddValidationError(ValidationError validationError)
        {
            this.ValidationErrors.Add(validationError);
        }
    }
}