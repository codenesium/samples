using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiProductReviewModelMapper
	{
		public virtual ApiProductReviewClientResponseModel MapClientRequestToResponse(
			int productReviewID,
			ApiProductReviewClientRequestModel request)
		{
			var response = new ApiProductReviewClientResponseModel();
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

		public virtual ApiProductReviewClientRequestModel MapClientResponseToRequest(
			ApiProductReviewClientResponseModel response)
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
	}
}

/*<Codenesium>
    <Hash>c0f7fecdfa4ad0c50bdf8623e883b082</Hash>
</Codenesium>*/