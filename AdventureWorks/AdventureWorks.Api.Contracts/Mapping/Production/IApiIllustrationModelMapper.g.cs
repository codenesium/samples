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
    <Hash>731871c67a513acfdc06a2452bfe7397</Hash>
</Codenesium>*/