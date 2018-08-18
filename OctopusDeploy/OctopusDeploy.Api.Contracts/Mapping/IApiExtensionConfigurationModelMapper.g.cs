using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiExtensionConfigurationModelMapper
	{
		ApiExtensionConfigurationResponseModel MapRequestToResponse(
			string id,
			ApiExtensionConfigurationRequestModel request);

		ApiExtensionConfigurationRequestModel MapResponseToRequest(
			ApiExtensionConfigurationResponseModel response);

		JsonPatchDocument<ApiExtensionConfigurationRequestModel> CreatePatch(ApiExtensionConfigurationRequestModel model);
	}
}

/*<Codenesium>
    <Hash>f1734cf09367e25c9257892b2909bc6b</Hash>
</Codenesium>*/