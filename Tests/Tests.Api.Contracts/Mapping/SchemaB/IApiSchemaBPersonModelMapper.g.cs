using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public interface IApiSchemaBPersonModelMapper
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
    <Hash>d8f74d7b34c1f036c852dcb34a49af2e</Hash>
</Codenesium>*/