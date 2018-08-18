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
    <Hash>aa1f4ecc923a2ba88d72e1056a11ce49</Hash>
</Codenesium>*/