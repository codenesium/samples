using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLDeploymentHistoryMapper
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
    <Hash>66cf4c0244eef16449d1c9daa96497d8</Hash>
</Codenesium>*/