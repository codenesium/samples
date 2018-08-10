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
    <Hash>9fe6d3500eef4e0593877fd4430113c1</Hash>
</Codenesium>*/