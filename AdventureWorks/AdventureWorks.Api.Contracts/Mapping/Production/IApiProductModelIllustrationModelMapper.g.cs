using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiProductModelIllustrationModelMapper
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
    <Hash>79de50fe033a740482332aaf1788420d</Hash>
</Codenesium>*/