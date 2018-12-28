using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Services
{
	public class RouteConstants
	{public const string DirectTweets = "directtweets";
	 public const string Followers = "followers";
	 public const string Followings = "followings";
	 public const string Likes = "likes";
	 public const string Locations = "locations";
	 public const string Messages = "messages";
	 public const string Messengers = "messengers";
	 public const string QuoteTweets = "quotetweets";
	 public const string Replies = "replies";
	 public const string Retweets = "retweets";
	 public const string Tweets = "tweets";
	 public const string Users = "users";}

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
    <Hash>0f3e3949e115997ce47a6e5f03ea9337</Hash>
</Codenesium>*/