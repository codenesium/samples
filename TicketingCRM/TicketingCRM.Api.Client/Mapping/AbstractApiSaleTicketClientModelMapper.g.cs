using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public abstract class AbstractApiSaleTicketModelMapper
	{
		public virtual ApiSaleTicketClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSaleTicketClientRequestModel request)
		{
			var response = new ApiSaleTicketClientResponseModel();
			response.SetProperties(id,
			                       request.SaleId,
			                       request.TicketId);
			return response;
		}

		public virtual ApiSaleTicketClientRequestModel MapClientResponseToRequest(
			ApiSaleTicketClientResponseModel response)
		{
			var request = new ApiSaleTicketClientRequestModel();
			request.SetProperties(
				response.SaleId,
				response.TicketId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>4d097c4952856297b0a8470736091325</Hash>
</Codenesium>*/