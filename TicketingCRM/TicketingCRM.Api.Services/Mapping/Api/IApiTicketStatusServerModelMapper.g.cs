using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiTicketStatusServerModelMapper
	{
		ApiTicketStatusServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTicketStatusServerRequestModel request);

		ApiTicketStatusServerRequestModel MapServerResponseToRequest(
			ApiTicketStatusServerResponseModel response);

		ApiTicketStatusClientRequestModel MapServerResponseToClientRequest(
			ApiTicketStatusServerResponseModel response);

		JsonPatchDocument<ApiTicketStatusServerRequestModel> CreatePatch(ApiTicketStatusServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>0b9d712bf5dc95631521afd821490d4d</Hash>
</Codenesium>*/