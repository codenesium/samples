using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiAWBuildVersionModelMapper
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
    <Hash>b0247d9966bbccbffcfe4a93630f2316</Hash>
</Codenesium>*/