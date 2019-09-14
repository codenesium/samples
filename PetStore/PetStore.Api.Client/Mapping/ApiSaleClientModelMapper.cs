using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Client
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
			                       request.FirstName,
			                       request.LastName,
			                       request.PaymentTypeId,
			                       request.PetId,
			                       request.Phone);
			return response;
		}

		public virtual ApiSaleClientRequestModel MapClientResponseToRequest(
			ApiSaleClientResponseModel response)
		{
			var request = new ApiSaleClientRequestModel();
			request.SetProperties(
				response.Amount,
				response.FirstName,
				response.LastName,
				response.PaymentTypeId,
				response.PetId,
				response.Phone);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>fd5a1db3b1ed870b594a60dbfc50206c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/