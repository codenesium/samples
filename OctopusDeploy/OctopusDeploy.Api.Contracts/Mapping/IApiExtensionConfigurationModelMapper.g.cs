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
    <Hash>70205fdd47494f168a21edb4a25d8862</Hash>
</Codenesium>*/