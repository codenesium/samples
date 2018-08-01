using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public interface IApiTableModelMapper
	{
		ApiTableResponseModel MapRequestToResponse(
			int id,
			ApiTableRequestModel request);

		ApiTableRequestModel MapResponseToRequest(
			ApiTableResponseModel response);

		JsonPatchDocument<ApiTableRequestModel> CreatePatch(ApiTableRequestModel model);
	}
}

/*<Codenesium>
    <Hash>0e56b2b8a0ea93b39c57061c8cefef2b</Hash>
</Codenesium>*/