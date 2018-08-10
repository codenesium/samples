using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiProjectGroupModelMapper
	{
		ApiProjectGroupResponseModel MapRequestToResponse(
			string id,
			ApiProjectGroupRequestModel request);

		ApiProjectGroupRequestModel MapResponseToRequest(
			ApiProjectGroupResponseModel response);

		JsonPatchDocument<ApiProjectGroupRequestModel> CreatePatch(ApiProjectGroupRequestModel model);
	}
}

/*<Codenesium>
    <Hash>6d505c21dcc46b7dbbbdabc1003c2556</Hash>
</Codenesium>*/