using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public partial interface IApiSchemaBPersonModelMapper
	{
		ApiSchemaBPersonResponseModel MapRequestToResponse(
			int id,
			ApiSchemaBPersonRequestModel request);

		ApiSchemaBPersonRequestModel MapResponseToRequest(
			ApiSchemaBPersonResponseModel response);

		JsonPatchDocument<ApiSchemaBPersonRequestModel> CreatePatch(ApiSchemaBPersonRequestModel model);
	}
}

/*<Codenesium>
    <Hash>3135a10167c98b6d298d023951fbac5b</Hash>
</Codenesium>*/