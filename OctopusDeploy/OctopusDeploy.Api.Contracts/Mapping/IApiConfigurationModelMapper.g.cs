using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiConfigurationModelMapper
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
    <Hash>d9c3376edb5e155a8b08bb8617e128e1</Hash>
</Codenesium>*/