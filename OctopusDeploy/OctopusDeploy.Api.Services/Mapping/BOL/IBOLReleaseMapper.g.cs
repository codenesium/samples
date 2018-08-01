using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLReleaseMapper
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
    <Hash>111db41866c8f7520af32994a2996837</Hash>
</Codenesium>*/