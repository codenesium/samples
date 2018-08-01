using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiApiKeyModelMapper
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
    <Hash>8d0768d0aa46e94ed5a2b25ae81c69fc</Hash>
</Codenesium>*/