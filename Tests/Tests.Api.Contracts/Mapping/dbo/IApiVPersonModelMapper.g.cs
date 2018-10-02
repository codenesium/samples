using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public partial interface IApiVPersonModelMapper
	{
		ApiVPersonResponseModel MapRequestToResponse(
			int personId,
			ApiVPersonRequestModel request);

		ApiVPersonRequestModel MapResponseToRequest(
			ApiVPersonResponseModel response);

		JsonPatchDocument<ApiVPersonRequestModel> CreatePatch(ApiVPersonRequestModel model);
	}
}

/*<Codenesium>
    <Hash>4f61c124134cc75ab914d96915934ed4</Hash>
</Codenesium>*/