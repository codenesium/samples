using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiDashboardConfigurationModelMapper
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
    <Hash>debdf6c5dc4f2b2829f7c5cafa1fcad3</Hash>
</Codenesium>*/