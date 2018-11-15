using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Client
{
	public abstract class AbstractApiSaleModelMapper
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
    <Hash>eef107db9f2c2e54149468ef7b6da0e5</Hash>
</Codenesium>*/