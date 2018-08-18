using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLDeploymentRelatedMachineMapper
	{
		BODeploymentRelatedMachine MapModelToBO(
			int id,
			ApiDeploymentRelatedMachineRequestModel model);

		ApiDeploymentRelatedMachineResponseModel MapBOToModel(
			BODeploymentRelatedMachine boDeploymentRelatedMachine);

		List<ApiDeploymentRelatedMachineResponseModel> MapBOToModel(
			List<BODeploymentRelatedMachine> items);
	}
}

/*<Codenesium>
    <Hash>82cc39db751a9bbd85d62da0aa0aec36</Hash>
</Codenesium>*/