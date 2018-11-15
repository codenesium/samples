using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiProductReviewServerModelMapper
	{
		public virtual ApiProductReviewServerResponseModel MapServerRequestToResponse(
			int productReviewID,
			ApiProductReviewServerRequestModel request)
		{
			var response = new ApiProductReviewServerResponseModel();
			response.SetProperties(productReviewID,
			                       request.Comment,
			                       request.EmailAddress,
			                       request.ModifiedDate,
			                       request.ProductID,
			                       request.Rating,
			                       request.ReviewDate,
			                       request.ReviewerName);
			return response;
		}

		public virtual ApiProductReviewServerRequestModel MapServerResponseToRequest(
			ApiProductReviewServerResponseModel response)
		{
			var request = new ApiProductReviewServerRequestModel();
			request.SetProperties(
				response.Comment,
				response.EmailAddress,
				response.ModifiedDate,
				response.ProductID,
				response.Rating,
				response.ReviewDate,
				response.ReviewerName);
			return request;
		}

		public virtual ApiProductReviewClientRequestModel MapServerResponseToClientRequest(
			ApiProductReviewServerResponseModel response)
		{
			var request = new ApiProductReviewClientRequestModel();
			request.SetProperties(
				response.Comment,
				response.EmailAddress,
				response.ModifiedDate,
				response.ProductID,
				response.Rating,
				response.ReviewDate,
				response.ReviewerName);
			return request;
		}

		public JsonPatchDocument<ApiProductReviewServerRequestModel> CreatePatch(ApiProductReviewServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiProductReviewServerRequestModel>();
			patch.Replace(x => x.Comment, model.Comment);
			patch.Replace(x => x.EmailAddress, model.EmailAddress);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.ProductID, model.ProductID);
			patch.Replace(x => x.Rating, model.Rating);
			patch.Replace(x => x.ReviewDate, model.ReviewDate);
			patch.Replace(x => x.ReviewerName, model.ReviewerName);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>91f9878df75db4bd05994a967f42c1c1</Hash>
</Codenesium>*/