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
    <Hash>c4c7c85a93a7ed351ff378117085f813</Hash>
</Codenesium>*/