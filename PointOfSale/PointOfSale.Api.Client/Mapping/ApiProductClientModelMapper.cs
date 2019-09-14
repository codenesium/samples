using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Client
{
	public class ApiProductModelMapper : IApiProductModelMapper
	{
		public virtual ApiProductClientResponseModel MapClientRequestToResponse(
			int id,
			ApiProductClientRequestModel request)
		{
			var response = new ApiProductClientResponseModel();
			response.SetProperties(id,
			                       request.Active,
			                       request.Description,
			                       request.Name,
			                       request.Price,
			                       request.Quantity);
			return response;
		}

		public virtual ApiProductClientRequestModel MapClientResponseToRequest(
			ApiProductClientResponseModel response)
		{
			var request = new ApiProductClientRequestModel();
			request.SetProperties(
				response.Active,
				response.Description,
				response.Name,
				response.Price,
				response.Quantity);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>c3786c5094de2e2d7a2eaf1dce936baf</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/