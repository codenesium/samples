using ESPIOTPostgresNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESPIOTPostgresNS.Api.Services
{
	public abstract class AbstractService
	{
	}

	public abstract class AbstractBusinessObject
	{
	}

	public static class ValidationResponseFactory<T>
	{
		public static CreateResponse<T> CreateResponse(T record)
		{
			return new CreateResponse<T>(record);
		}

		public static CreateResponse<T> CreateResponse(ValidationResult result)
		{
			var response = new CreateResponse<T>();
			response.Success = result.IsValid;
			foreach (ValidationFailure error in result.Errors)
			{
				response.ValidationErrors.Add(new ValidationError(error.ErrorCode, error.ErrorMessage, error.PropertyName));
			}

			return response;
		}

		public static UpdateResponse<T> UpdateResponse(T record)
		{
			return new UpdateResponse<T>(record);
		}

		public static UpdateResponse<T> UpdateResponse(ValidationResult result)
		{
			var response = new UpdateResponse<T>();
			response.Success = result.IsValid;
			foreach (ValidationFailure error in result.Errors)
			{
				response.ValidationErrors.Add(new ValidationError(error.ErrorCode, error.ErrorMessage, error.PropertyName));
			}

			return response;
		}

		public static ActionResponse ActionResponse(ValidationResult result)
		{
			var response = new ActionResponse();
			response.Success = result.IsValid;
			foreach (ValidationFailure error in result.Errors)
			{
				response.ValidationErrors.Add(new ValidationError(error.ErrorCode, error.ErrorMessage, error.PropertyName));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b3de656d10b5f18d1e79fec8dcc15b5d</Hash>
</Codenesium>*/