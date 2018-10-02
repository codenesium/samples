using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Contracts
{
	public partial interface IApiLikeModelMapper
	{
		ApiLikeResponseModel MapRequestToResponse(
			int likeId,
			ApiLikeRequestModel request);

		ApiLikeRequestModel MapResponseToRequest(
			ApiLikeResponseModel response);

		JsonPatchDocument<ApiLikeRequestModel> CreatePatch(ApiLikeRequestModel model);
	}
}

/*<Codenesium>
    <Hash>346a9cdbb66f7a56110ed1540d7c1f0f</Hash>
</Codenesium>*/