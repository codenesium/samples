using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLDashboardConfigurationMapper
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
    <Hash>550c7f58b8d78561e5a6d6ea6772e9ac</Hash>
</Codenesium>*/