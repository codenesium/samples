using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLDeploymentEnvironmentMapper
	{
		BODeploymentEnvironment MapModelToBO(
			string id,
			ApiDeploymentEnvironmentRequestModel model);

		ApiDeploymentEnvironmentResponseModel MapBOToModel(
			BODeploymentEnvironment boDeploymentEnvironment);

		List<ApiDeploymentEnvironmentResponseModel> MapBOToModel(
			List<BODeploymentEnvironment> items);
	}
}

/*<Codenesium>
    <Hash>fb8b98062abeb6ea578dc1e3e3d4f4f7</Hash>
</Codenesium>*/