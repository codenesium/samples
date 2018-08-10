using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiApiKeyModelMapper
	{
		ApiApiKeyResponseModel MapRequestToResponse(
			string id,
			ApiApiKeyRequestModel request);

		ApiApiKeyRequestModel MapResponseToRequest(
			ApiApiKeyResponseModel response);

		JsonPatchDocument<ApiApiKeyRequestModel> CreatePatch(ApiApiKeyRequestModel model);
	}
}

/*<Codenesium>
    <Hash>412a954e0ee38053082e97209b19f6f7</Hash>
</Codenesium>*/