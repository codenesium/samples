using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiCustomerServerModelMapper
	{
		ApiCustomerServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCustomerServerRequestModel request);

		ApiCustomerServerRequestModel MapServerResponseToRequest(
			ApiCustomerServerResponseModel response);

		ApiCustomerClientRequestModel MapServerResponseToClientRequest(
			ApiCustomerServerResponseModel response);

		JsonPatchDocument<ApiCustomerServerRequestModel> CreatePatch(ApiCustomerServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>18934c3cc7d804de01d17730052af3c7</Hash>
</Codenesium>*/