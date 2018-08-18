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
    <Hash>b0d2a5d6053f68926dd45afd4ce491ea</Hash>
</Codenesium>*/