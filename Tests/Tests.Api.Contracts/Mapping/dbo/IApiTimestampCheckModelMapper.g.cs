using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public partial interface IApiTimestampCheckModelMapper
	{
		ApiTimestampCheckResponseModel MapRequestToResponse(
			int id,
			ApiTimestampCheckRequestModel request);

		ApiTimestampCheckRequestModel MapResponseToRequest(
			ApiTimestampCheckResponseModel response);

		JsonPatchDocument<ApiTimestampCheckRequestModel> CreatePatch(ApiTimestampCheckRequestModel model);
	}
}

/*<Codenesium>
    <Hash>aa04e7cb9ecc663f5f1e5f0097a90a45</Hash>
</Codenesium>*/