using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public abstract class AbstractApiSaleTicketsModelMapper
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
    <Hash>3dd4e6465dc3948c0f9226f9017aae37</Hash>
</Codenesium>*/