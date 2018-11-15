using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
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
    <Hash>8f40a28f2c6ec618af747c98acb8fe35</Hash>
</Codenesium>*/