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
    <Hash>6f8445fe47071c3f64ac329ebe611713</Hash>
</Codenesium>*/