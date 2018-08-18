using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLDeploymentHistoryMapper
	{
		BODeploymentHistory MapModelToBO(
			string deploymentId,
			ApiDeploymentHistoryRequestModel model);

		ApiDeploymentHistoryResponseModel MapBOToModel(
			BODeploymentHistory boDeploymentHistory);

		List<ApiDeploymentHistoryResponseModel> MapBOToModel(
			List<BODeploymentHistory> items);
	}
}

/*<Codenesium>
    <Hash>b1f44c808ee7a7821d7a391abe4fb1d0</Hash>
</Codenesium>*/