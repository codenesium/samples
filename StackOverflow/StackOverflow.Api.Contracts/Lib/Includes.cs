using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflowNS.Api.Contracts
{
	public class AuthErrorCodes
	{
		public const string UserDoesNotExist = "UserDoesNotExist";
		public const string InvalidUsernameOrPassword = "InvalidUsernameOrPassword";
		public const string UnableToRegister = "UnableToRegister";
		public const string UserAlreadyExists = "UserAlreadyExists";
		public const string UnableToConfirmRegistration = "UnableToConfirmRegistration";
		public const string UnableToConfirmPasssordReset = "UnableToConfirmPasssordReset";
		public const string UnableToChangePassword = "UnableToChangePassword";
	}

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

		public class AuthResponse : ActionResponse
		{
			[JsonProperty]
			public virtual string Token { get; private set; }

			[JsonProperty]
			public virtual string LinkText { get; private set; }

			[JsonProperty]
			public virtual string LinkValue { get; private set; }

			[JsonProperty]
			public virtual string Message { get; private set; }

			[JsonProperty]
			public virtual string ErrorCode { get; private set; }

			public virtual void SetMessage(string message)
			{
				this.Message = message;
			}

		    public virtual void SetLink(string linkText, string linkValue)
			{
				this.LinkText = linkText;
				this.LinkValue = linkValue;
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
}