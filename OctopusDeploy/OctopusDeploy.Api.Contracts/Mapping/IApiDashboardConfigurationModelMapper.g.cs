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
    <Hash>a787c2c7fb1d4ba4c9d313e3fe078737</Hash>
</Codenesium>*/