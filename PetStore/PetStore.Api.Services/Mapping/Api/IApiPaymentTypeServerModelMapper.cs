using Microsoft.AspNetCore.JsonPatch;
using PetStoreNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface IApiPaymentTypeServerModelMapper
	{
		ApiPaymentTypeServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPaymentTypeServerRequestModel request);

		ApiPaymentTypeServerRequestModel MapServerResponseToRequest(
			ApiPaymentTypeServerResponseModel response);

		ApiPaymentTypeClientRequestModel MapServerResponseToClientRequest(
			ApiPaymentTypeServerResponseModel response);

		JsonPatchDocument<ApiPaymentTypeServerRequestModel> CreatePatch(ApiPaymentTypeServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>99f943111d523b7e7ac53231b2d7f8a0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/