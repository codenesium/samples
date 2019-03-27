using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Client
{
	public abstract class AbstractApiProductModelMapper
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
    <Hash>d69c9942bd57ba381ec7cdaf639134ba</Hash>
</Codenesium>*/