using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiSaleTicketsServerModelMapper
	{
		ApiSaleTicketsServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSaleTicketsServerRequestModel request);

		ApiSaleTicketsServerRequestModel MapServerResponseToRequest(
			ApiSaleTicketsServerResponseModel response);

		ApiSaleTicketsClientRequestModel MapServerResponseToClientRequest(
			ApiSaleTicketsServerResponseModel response);

		JsonPatchDocument<ApiSaleTicketsServerRequestModel> CreatePatch(ApiSaleTicketsServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>fc266876ec37837ed71f18fb9538dd3e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/