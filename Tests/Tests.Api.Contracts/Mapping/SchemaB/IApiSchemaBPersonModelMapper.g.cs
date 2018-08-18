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
    <Hash>2c8e1178cc3830d47124e6f3b631360d</Hash>
</Codenesium>*/