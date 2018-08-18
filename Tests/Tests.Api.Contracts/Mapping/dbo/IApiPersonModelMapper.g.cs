using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public partial interface IApiPersonModelMapper
	{
		ApiPersonResponseModel MapRequestToResponse(
			int personId,
			ApiPersonRequestModel request);

		ApiPersonRequestModel MapResponseToRequest(
			ApiPersonResponseModel response);

		JsonPatchDocument<ApiPersonRequestModel> CreatePatch(ApiPersonRequestModel model);
	}
}

/*<Codenesium>
    <Hash>f142f14aab448304d1115ed66ae5df73</Hash>
</Codenesium>*/