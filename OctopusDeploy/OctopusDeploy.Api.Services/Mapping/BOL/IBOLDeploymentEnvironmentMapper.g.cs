using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLDeploymentEnvironmentMapper
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
    <Hash>9933480187fc6b15655dbca5eae51f13</Hash>
</Codenesium>*/