using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiProductReviewModelMapper
	{
		ApiProductReviewResponseModel MapRequestToResponse(
			int productReviewID,
			ApiProductReviewRequestModel request);

		ApiProductReviewRequestModel MapResponseToRequest(
			ApiProductReviewResponseModel response);

		JsonPatchDocument<ApiProductReviewRequestModel> CreatePatch(ApiProductReviewRequestModel model);
	}
}

/*<Codenesium>
    <Hash>ff12e99701f8bfb3f8ddd35648bb014c</Hash>
</Codenesium>*/