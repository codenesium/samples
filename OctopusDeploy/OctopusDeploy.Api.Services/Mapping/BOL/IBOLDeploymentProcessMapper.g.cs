using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLDeploymentProcessMapper
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
    <Hash>e0fa187fccc99cc1295a06dadfdc9b0a</Hash>
</Codenesium>*/