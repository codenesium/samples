using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public class ApiSaleTicketsModelMapper : IApiSaleTicketsModelMapper
	{
		public virtual ApiSaleTicketsClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSaleTicketsClientRequestModel request)
		{
			var response = new ApiSaleTicketsClientResponseModel();
			response.SetProperties(id,
			                       request.SaleId,
			                       request.TicketId);
			return response;
		}

		public virtual ApiSaleTicketsClientRequestModel MapClientResponseToRequest(
			ApiSaleTicketsClientResponseModel response)
		{
			var request = new ApiSaleTicketsClientRequestModel();
			request.SetProperties(
				response.SaleId,
				response.TicketId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>f70afa2c7ae406b6df7fd54b291f43ae</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/