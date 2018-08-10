using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLDeploymentProcessMapper
	{
		BODeploymentProcess MapModelToBO(
			string id,
			ApiDeploymentProcessRequestModel model);

		ApiDeploymentProcessResponseModel MapBOToModel(
			BODeploymentProcess boDeploymentProcess);

		List<ApiDeploymentProcessResponseModel> MapBOToModel(
			List<BODeploymentProcess> items);
	}
}

/*<Codenesium>
    <Hash>a3c607e8d7c2e7e9260ce6de033cc9d7</Hash>
</Codenesium>*/