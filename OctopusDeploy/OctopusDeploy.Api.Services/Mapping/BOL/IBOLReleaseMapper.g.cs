using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLReleaseMapper
	{
		BORelease MapModelToBO(
			string id,
			ApiReleaseRequestModel model);

		ApiReleaseResponseModel MapBOToModel(
			BORelease boRelease);

		List<ApiReleaseResponseModel> MapBOToModel(
			List<BORelease> items);
	}
}

/*<Codenesium>
    <Hash>8e7fa919480dade19b71aeb734040016</Hash>
</Codenesium>*/