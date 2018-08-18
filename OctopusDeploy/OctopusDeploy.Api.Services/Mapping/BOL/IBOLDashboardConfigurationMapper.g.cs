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
    <Hash>779eff2f65bef32528a49d4e99958fd5</Hash>
</Codenesium>*/