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
    <Hash>4311574c84c612366cee0eed7f0d68c8</Hash>
</Codenesium>*/