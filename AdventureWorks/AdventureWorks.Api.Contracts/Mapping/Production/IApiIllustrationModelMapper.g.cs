using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiIllustrationModelMapper
	{
		ApiIllustrationResponseModel MapRequestToResponse(
			int illustrationID,
			ApiIllustrationRequestModel request);

		ApiIllustrationRequestModel MapResponseToRequest(
			ApiIllustrationResponseModel response);

		JsonPatchDocument<ApiIllustrationRequestModel> CreatePatch(ApiIllustrationRequestModel model);
	}
}

/*<Codenesium>
    <Hash>e29cec1d93c8c745d9569682eb5f3fd0</Hash>
</Codenesium>*/