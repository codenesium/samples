using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiProductModelModelMapper
	{
		ApiProductModelResponseModel MapRequestToResponse(
			int productModelID,
			ApiProductModelRequestModel request);

		ApiProductModelRequestModel MapResponseToRequest(
			ApiProductModelResponseModel response);

		JsonPatchDocument<ApiProductModelRequestModel> CreatePatch(ApiProductModelRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b92b51578ccd37e0d55061ae9c82a632</Hash>
</Codenesium>*/