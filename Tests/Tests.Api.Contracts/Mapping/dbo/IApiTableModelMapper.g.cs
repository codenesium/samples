using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public partial interface IApiTableModelMapper
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
    <Hash>64e1dcd5eacb96458a3f82cfedf627c5</Hash>
</Codenesium>*/