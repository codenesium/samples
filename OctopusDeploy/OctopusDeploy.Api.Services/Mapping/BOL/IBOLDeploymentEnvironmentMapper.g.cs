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
    <Hash>d8e5b95027d7509f1751d41c50e59fb7</Hash>
</Codenesium>*/