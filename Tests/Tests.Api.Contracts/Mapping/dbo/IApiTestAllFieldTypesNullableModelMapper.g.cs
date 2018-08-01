using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public interface IApiTestAllFieldTypesNullableModelMapper
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
    <Hash>a169cc4238e09dafa6635ccdbbc9e60b</Hash>
</Codenesium>*/