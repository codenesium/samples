using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiOffCapabilityServerModelMapper
	{
		ApiOffCapabilityServerResponseModel MapServerRequestToResponse(
			int id,
			ApiOffCapabilityServerRequestModel request);

		ApiOffCapabilityServerRequestModel MapServerResponseToRequest(
			ApiOffCapabilityServerResponseModel response);

		ApiOffCapabilityClientRequestModel MapServerResponseToClientRequest(
			ApiOffCapabilityServerResponseModel response);

		JsonPatchDocument<ApiOffCapabilityServerRequestModel> CreatePatch(ApiOffCapabilityServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>89d37b0e7a7df106bb10d4f6d5fcbacc</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/