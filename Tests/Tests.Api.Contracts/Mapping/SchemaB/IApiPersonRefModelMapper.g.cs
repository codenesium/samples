using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public partial interface IApiPersonRefModelMapper
	{
		ApiPersonRefResponseModel MapRequestToResponse(
			int id,
			ApiPersonRefRequestModel request);

		ApiPersonRefRequestModel MapResponseToRequest(
			ApiPersonRefResponseModel response);

		JsonPatchDocument<ApiPersonRefRequestModel> CreatePatch(ApiPersonRefRequestModel model);
	}
}

/*<Codenesium>
    <Hash>50457873dbeb5da5d4968fed29463b1f</Hash>
</Codenesium>*/