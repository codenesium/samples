using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public class ApiSaleModelMapper : IApiSaleModelMapper
	{
		public virtual ApiSaleClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSaleClientRequestModel request)
		{
			var response = new ApiSaleClientResponseModel();
			response.SetProperties(id,
			                       request.Amount,
			                       request.CutomerId,
			                       request.Note,
			                       request.PetId,
			                       request.SaleDate,
			                       request.SalesPersonId);
			return response;
		}

		public virtual ApiSaleClientRequestModel MapClientResponseToRequest(
			ApiSaleClientResponseModel response)
		{
			var request = new ApiSaleClientRequestModel();
			request.SetProperties(
				response.Amount,
				response.CutomerId,
				response.Note,
				response.PetId,
				response.SaleDate,
				response.SalesPersonId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>121b1568228eb9d0f0420d5aa73cc5ca</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/