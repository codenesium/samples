using ESPIOTNS.Api.Contracts;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESPIOTNS.Api.Services
{

	public class ApiSettings
	{
		public virtual string DatabaseProvider { get; set; }

		public virtual string ExternalBaseUrl { get; set; }

		public virtual bool MigrateDatabase { get; set; }

		public virtual bool SecurityEnabled { get; set; }

		public virtual JwtSettings JwtSettings { get; set; }
	}

	public class JwtSettings
	{
		public virtual string SigningKey { get; set; }

		public virtual string Issuer { get; set; }

		public virtual string Audience { get; set; }
	}

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

		public static AuthResponse AuthResponse(bool success, string message, string errorCode, string token, string link)
		{
			var response = new AuthResponse();
			response.Success = success;
			response.SetLink(link);
			response.SetMessage(message);
			response.SetToken(token);
			response.SetErrorCode(errorCode);

			return response;
		}

		public static AuthResponse AuthResponse(bool success, IdentityResult identityResult, string errorCode, string token, string link)
		{
			var response = new AuthResponse();
			response.Success = success;
			response.SetLink(link);

			string message = string.Empty;
			foreach (var error in identityResult.Errors)
			{
				message += error.Description + Environment.NewLine;
			}

			response.SetMessage(message);
			response.SetToken(token);
			response.SetErrorCode(errorCode);

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f1e61622f99d9d6549054382cd0b8f48</Hash>
</Codenesium>*/