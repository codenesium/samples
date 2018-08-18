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
    <Hash>7fc3089c35df0c5f54b1d7c1a06803df</Hash>
</Codenesium>*/