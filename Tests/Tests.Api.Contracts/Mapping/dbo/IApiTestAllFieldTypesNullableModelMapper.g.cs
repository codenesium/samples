using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public partial interface IApiTestAllFieldTypesNullableModelMapper
	{
		ApiTestAllFieldTypesNullableResponseModel MapRequestToResponse(
			int id,
			ApiTestAllFieldTypesNullableRequestModel request);

		ApiTestAllFieldTypesNullableRequestModel MapResponseToRequest(
			ApiTestAllFieldTypesNullableResponseModel response);

		JsonPatchDocument<ApiTestAllFieldTypesNullableRequestModel> CreatePatch(ApiTestAllFieldTypesNullableRequestModel model);
	}
}

/*<Codenesium>
    <Hash>6975aaae79aeb196d62820debf396174</Hash>
</Codenesium>*/