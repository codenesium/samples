using Microsoft.AspNetCore.JsonPatch;
using PetStoreNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface IApiPenServerModelMapper
	{
		ApiPenServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPenServerRequestModel request);

		ApiPenServerRequestModel MapServerResponseToRequest(
			ApiPenServerResponseModel response);

		ApiPenClientRequestModel MapServerResponseToClientRequest(
			ApiPenServerResponseModel response);

		JsonPatchDocument<ApiPenServerRequestModel> CreatePatch(ApiPenServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>f594fbad3aa849cc4cd51be53a0b94ea</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/