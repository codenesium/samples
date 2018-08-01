using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiConfigurationModelMapper
	{
		ApiConfigurationResponseModel MapRequestToResponse(
			string id,
			ApiConfigurationRequestModel request);

		ApiConfigurationRequestModel MapResponseToRequest(
			ApiConfigurationResponseModel response);

		JsonPatchDocument<ApiConfigurationRequestModel> CreatePatch(ApiConfigurationRequestModel model);
	}
}

/*<Codenesium>
    <Hash>ab62431691ea283673748eec8cd759b3</Hash>
</Codenesium>*/