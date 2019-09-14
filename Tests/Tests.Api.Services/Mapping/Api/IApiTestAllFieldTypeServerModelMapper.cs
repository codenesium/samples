using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public partial interface IApiTestAllFieldTypeServerModelMapper
	{
		ApiTestAllFieldTypeServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTestAllFieldTypeServerRequestModel request);

		ApiTestAllFieldTypeServerRequestModel MapServerResponseToRequest(
			ApiTestAllFieldTypeServerResponseModel response);

		ApiTestAllFieldTypeClientRequestModel MapServerResponseToClientRequest(
			ApiTestAllFieldTypeServerResponseModel response);

		JsonPatchDocument<ApiTestAllFieldTypeServerRequestModel> CreatePatch(ApiTestAllFieldTypeServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>4691f2c433609c74bb102a738d1aa0b1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/