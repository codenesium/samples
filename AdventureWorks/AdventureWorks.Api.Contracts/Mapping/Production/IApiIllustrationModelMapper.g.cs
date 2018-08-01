using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiIllustrationModelMapper
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
    <Hash>ad303db840e638fe4c0fc427a41e2c3c</Hash>
</Codenesium>*/