using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiTransactionServerModelMapper
	{
		ApiTransactionServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTransactionServerRequestModel request);

		ApiTransactionServerRequestModel MapServerResponseToRequest(
			ApiTransactionServerResponseModel response);

		ApiTransactionClientRequestModel MapServerResponseToClientRequest(
			ApiTransactionServerResponseModel response);

		JsonPatchDocument<ApiTransactionServerRequestModel> CreatePatch(ApiTransactionServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>5e5eb576919d95f77a060dc858d31929</Hash>
</Codenesium>*/