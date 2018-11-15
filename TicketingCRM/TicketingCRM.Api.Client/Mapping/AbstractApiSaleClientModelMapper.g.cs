using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public abstract class AbstractApiSaleModelMapper
	{
		public virtual ApiSaleClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSaleClientRequestModel request)
		{
			var response = new ApiSaleClientResponseModel();
			response.SetProperties(id,
			                       request.IpAddress,
			                       request.Note,
			                       request.SaleDate,
			                       request.TransactionId);
			return response;
		}

		public virtual ApiSaleClientRequestModel MapClientResponseToRequest(
			ApiSaleClientResponseModel response)
		{
			var request = new ApiSaleClientRequestModel();
			request.SetProperties(
				response.IpAddress,
				response.Note,
				response.SaleDate,
				response.TransactionId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>870dcb748c9c0a2749b9b31d151c15b5</Hash>
</Codenesium>*/