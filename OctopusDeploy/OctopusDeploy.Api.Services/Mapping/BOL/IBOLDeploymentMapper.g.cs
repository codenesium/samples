using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLDeploymentMapper
	{
		BODeployment MapModelToBO(
			string id,
			ApiDeploymentRequestModel model);

		ApiDeploymentResponseModel MapBOToModel(
			BODeployment boDeployment);

		List<ApiDeploymentResponseModel> MapBOToModel(
			List<BODeployment> items);
	}
}

/*<Codenesium>
    <Hash>94f8d9324cdf65ad21e2179ccafb1d96</Hash>
</Codenesium>*/