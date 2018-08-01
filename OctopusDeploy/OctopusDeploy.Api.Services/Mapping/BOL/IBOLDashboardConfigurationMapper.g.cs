using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLDashboardConfigurationMapper
	{
		BODashboardConfiguration MapModelToBO(
			string id,
			ApiDashboardConfigurationRequestModel model);

		ApiDashboardConfigurationResponseModel MapBOToModel(
			BODashboardConfiguration boDashboardConfiguration);

		List<ApiDashboardConfigurationResponseModel> MapBOToModel(
			List<BODashboardConfiguration> items);
	}
}

/*<Codenesium>
    <Hash>9e0f2025c7019aa8324edf47c127417a</Hash>
</Codenesium>*/