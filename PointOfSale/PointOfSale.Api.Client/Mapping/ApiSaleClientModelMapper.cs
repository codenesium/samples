using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Client
{
	public class ApiSaleModelMapper : IApiSaleModelMapper
	{
		public virtual ApiSaleClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSaleClientRequestModel request)
		{
			var response = new ApiSaleClientResponseModel();
			response.SetProperties(id,
			                       request.CustomerId,
			                       request.Date);
			return response;
		}

		public virtual ApiSaleClientRequestModel MapClientResponseToRequest(
			ApiSaleClientResponseModel response)
		{
			var request = new ApiSaleClientRequestModel();
			request.SetProperties(
				response.CustomerId,
				response.Date);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>264beac29b8dc6defe6b9e20c9bd6619</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/