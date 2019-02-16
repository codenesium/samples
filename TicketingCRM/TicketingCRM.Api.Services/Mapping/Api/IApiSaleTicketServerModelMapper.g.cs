using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiSaleTicketServerModelMapper
	{
		ApiSaleTicketServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSaleTicketServerRequestModel request);

		ApiSaleTicketServerRequestModel MapServerResponseToRequest(
			ApiSaleTicketServerResponseModel response);

		ApiSaleTicketClientRequestModel MapServerResponseToClientRequest(
			ApiSaleTicketServerResponseModel response);

		JsonPatchDocument<ApiSaleTicketServerRequestModel> CreatePatch(ApiSaleTicketServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>8054941d7b97e25bd02052f091fad3f7</Hash>
</Codenesium>*/