using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public class ApiSaleModelMapper : IApiSaleModelMapper
	{
		public virtual ApiSaleClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSaleClientRequestModel request)
		{
			var response = new ApiSaleClientResponseModel();
			response.SetProperties(id,
			                       request.IpAddress,
			                       request.Notes,
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
				response.Notes,
				response.SaleDate,
				response.TransactionId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>a4552c275672f2e413f9790ca9a90c7f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/