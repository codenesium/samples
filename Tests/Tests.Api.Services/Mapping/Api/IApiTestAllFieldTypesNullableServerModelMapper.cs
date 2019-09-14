using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public partial interface IApiTestAllFieldTypesNullableServerModelMapper
	{
		ApiTestAllFieldTypesNullableServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTestAllFieldTypesNullableServerRequestModel request);

		ApiTestAllFieldTypesNullableServerRequestModel MapServerResponseToRequest(
			ApiTestAllFieldTypesNullableServerResponseModel response);

		ApiTestAllFieldTypesNullableClientRequestModel MapServerResponseToClientRequest(
			ApiTestAllFieldTypesNullableServerResponseModel response);

		JsonPatchDocument<ApiTestAllFieldTypesNullableServerRequestModel> CreatePatch(ApiTestAllFieldTypesNullableServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>3529e3c740e6b25f9e84af7164fc7adc</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/