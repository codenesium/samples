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
    <Hash>962fbc9df0b662c5d56ee63242d19f30</Hash>
</Codenesium>*/