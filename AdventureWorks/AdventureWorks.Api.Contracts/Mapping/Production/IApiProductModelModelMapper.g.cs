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
    <Hash>99fbeb83cb51fcd248e8d28dc6dea5f1</Hash>
</Codenesium>*/