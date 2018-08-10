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
    <Hash>ff92179d5c58f9a782710b2f2552c554</Hash>
</Codenesium>*/