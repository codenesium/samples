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
    <Hash>bade8604316a8777f027ef2300702fa5</Hash>
</Codenesium>*/