using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
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
    <Hash>ba624c2bdcf400754f32ac8fe20459c8</Hash>
</Codenesium>*/