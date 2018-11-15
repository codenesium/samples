using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiTicketStatuServerModelMapper
	{
		ApiTicketStatuServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTicketStatuServerRequestModel request);

		ApiTicketStatuServerRequestModel MapServerResponseToRequest(
			ApiTicketStatuServerResponseModel response);

		ApiTicketStatuClientRequestModel MapServerResponseToClientRequest(
			ApiTicketStatuServerResponseModel response);

		JsonPatchDocument<ApiTicketStatuServerRequestModel> CreatePatch(ApiTicketStatuServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>447d35160b491de84ca0deb66544b51a</Hash>
</Codenesium>*/