using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiExtensionConfigurationModelMapper
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
    <Hash>65c833bc41f1910bc590526095c9cb89</Hash>
</Codenesium>*/