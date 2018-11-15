using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiTransactionStatuServerModelMapper
	{
		ApiTransactionStatuServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTransactionStatuServerRequestModel request);

		ApiTransactionStatuServerRequestModel MapServerResponseToRequest(
			ApiTransactionStatuServerResponseModel response);

		ApiTransactionStatuClientRequestModel MapServerResponseToClientRequest(
			ApiTransactionStatuServerResponseModel response);

		JsonPatchDocument<ApiTransactionStatuServerRequestModel> CreatePatch(ApiTransactionStatuServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d7f2ee64c513f4485d71e07ed3bd44ae</Hash>
</Codenesium>*/