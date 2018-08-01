using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLDeploymentRelatedMachineMapper
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
    <Hash>06b5ed03ab75409bab16de731e0c3bdd</Hash>
</Codenesium>*/