using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiAWBuildVersionModelMapper
	{
		ApiAWBuildVersionResponseModel MapRequestToResponse(
			int systemInformationID,
			ApiAWBuildVersionRequestModel request);

		ApiAWBuildVersionRequestModel MapResponseToRequest(
			ApiAWBuildVersionResponseModel response);

		JsonPatchDocument<ApiAWBuildVersionRequestModel> CreatePatch(ApiAWBuildVersionRequestModel model);
	}
}

/*<Codenesium>
    <Hash>64f8b2e60958ed067d7eeadadf039576</Hash>
</Codenesium>*/