using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiHandlerServerModelMapper
	{
		ApiHandlerServerResponseModel MapServerRequestToResponse(
			int id,
			ApiHandlerServerRequestModel request);

		ApiHandlerServerRequestModel MapServerResponseToRequest(
			ApiHandlerServerResponseModel response);

		ApiHandlerClientRequestModel MapServerResponseToClientRequest(
			ApiHandlerServerResponseModel response);

		JsonPatchDocument<ApiHandlerServerRequestModel> CreatePatch(ApiHandlerServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>ca58238172fbb318f7dbb8e763441c77</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/