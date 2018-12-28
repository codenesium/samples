using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflowNS.Api.Services
{
	public class RouteConstants
	{public const string Badges = "badges";
	 public const string Comments = "comments";
	 public const string LinkTypes = "linktypes";
	 public const string PostHistories = "posthistories";
	 public const string PostHistoryTypes = "posthistorytypes";
	 public const string PostLinks = "postlinks";
	 public const string Posts = "posts";
	 public const string PostTypes = "posttypes";
	 public const string Tags = "tags";
	 public const string Users = "users";
	 public const string Votes = "votes";
	 public const string VoteTypes = "votetypes";}

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
    <Hash>2ea7aefe51c1216f0ac9192e991815cd</Hash>
</Codenesium>*/