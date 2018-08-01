using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiProductModelIllustrationModelMapper
	{
		ApiProductModelIllustrationResponseModel MapRequestToResponse(
			int productModelID,
			ApiProductModelIllustrationRequestModel request);

		ApiProductModelIllustrationRequestModel MapResponseToRequest(
			ApiProductModelIllustrationResponseModel response);

		JsonPatchDocument<ApiProductModelIllustrationRequestModel> CreatePatch(ApiProductModelIllustrationRequestModel model);
	}
}

/*<Codenesium>
    <Hash>34b871f5df9aa85c8afd6cfe8204e72a</Hash>
</Codenesium>*/