using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLDeploymentMapper
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
    <Hash>14b9524a6bd8cbb6d9c68a9caae8f769</Hash>
</Codenesium>*/