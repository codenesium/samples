using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiDashboardConfigurationModelMapper
	{
		ApiDashboardConfigurationResponseModel MapRequestToResponse(
			string id,
			ApiDashboardConfigurationRequestModel request);

		ApiDashboardConfigurationRequestModel MapResponseToRequest(
			ApiDashboardConfigurationResponseModel response);

		JsonPatchDocument<ApiDashboardConfigurationRequestModel> CreatePatch(ApiDashboardConfigurationRequestModel model);
	}
}

/*<Codenesium>
    <Hash>4b7d75ad2561bf8baa7fa65bc8d4c7c6</Hash>
</Codenesium>*/