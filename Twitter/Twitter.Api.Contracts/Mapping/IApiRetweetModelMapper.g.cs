using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Contracts
{
	public partial interface IApiRetweetModelMapper
	{
		ApiRetweetResponseModel MapRequestToResponse(
			int id,
			ApiRetweetRequestModel request);

		ApiRetweetRequestModel MapResponseToRequest(
			ApiRetweetResponseModel response);

		JsonPatchDocument<ApiRetweetRequestModel> CreatePatch(ApiRetweetRequestModel model);
	}
}

/*<Codenesium>
    <Hash>a3eb528e69b5cc7f2539e2b573ba3091</Hash>
</Codenesium>*/