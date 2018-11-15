using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductReviewServerModelMapper
	{
		ApiProductReviewServerResponseModel MapServerRequestToResponse(
			int productReviewID,
			ApiProductReviewServerRequestModel request);

		ApiProductReviewServerRequestModel MapServerResponseToRequest(
			ApiProductReviewServerResponseModel response);

		ApiProductReviewClientRequestModel MapServerResponseToClientRequest(
			ApiProductReviewServerResponseModel response);

		JsonPatchDocument<ApiProductReviewServerRequestModel> CreatePatch(ApiProductReviewServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>ef9ad63396bcb8de19a3141c87a81e0f</Hash>
</Codenesium>*/