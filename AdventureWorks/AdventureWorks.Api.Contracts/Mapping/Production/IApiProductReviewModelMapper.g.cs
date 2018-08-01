using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiProductReviewModelMapper
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
    <Hash>b4f767f9f924f72b23e554fb81ac445a</Hash>
</Codenesium>*/