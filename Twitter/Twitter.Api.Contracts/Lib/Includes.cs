using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterNS.Api.Contracts
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
        bool Success { get; set;}

        List<ValidationError> ValidationErrors { get; }
    }

    public class ActionResponse : IActionResponse
    {
		[JsonProperty]
        public virtual bool Success { get; set; }

		[JsonProperty]
        public virtual List<ValidationError> ValidationErrors { get; private set; } = new List<ValidationError>();
    }
}