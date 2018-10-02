using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Contracts
{
	public partial interface IApiLocationModelMapper
	{
		ApiLocationResponseModel MapRequestToResponse(
			int locationId,
			ApiLocationRequestModel request);

		ApiLocationRequestModel MapResponseToRequest(
			ApiLocationResponseModel response);

		JsonPatchDocument<ApiLocationRequestModel> CreatePatch(ApiLocationRequestModel model);
	}
}

/*<Codenesium>
    <Hash>a2394718c47254465389e7ed08af86ce</Hash>
</Codenesium>*/