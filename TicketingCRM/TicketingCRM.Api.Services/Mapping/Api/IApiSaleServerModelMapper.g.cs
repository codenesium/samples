using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiSaleServerModelMapper
	{
		ApiSaleServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSaleServerRequestModel request);

		ApiSaleServerRequestModel MapServerResponseToRequest(
			ApiSaleServerResponseModel response);

		ApiSaleClientRequestModel MapServerResponseToClientRequest(
			ApiSaleServerResponseModel response);

		JsonPatchDocument<ApiSaleServerRequestModel> CreatePatch(ApiSaleServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>c2c997949afd51d871df2bba77a62099</Hash>
</Codenesium>*/