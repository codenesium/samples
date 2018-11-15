using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public abstract class AbstractApiDestinationModelMapper
	{
		public virtual ApiDestinationClientResponseModel MapClientRequestToResponse(
			int id,
			ApiDestinationClientRequestModel request)
		{
			var response = new ApiDestinationClientResponseModel();
			response.SetProperties(id,
			                       request.CountryId,
			                       request.Name,
			                       request.Order);
			return response;
		}

		public virtual ApiDestinationClientRequestModel MapClientResponseToRequest(
			ApiDestinationClientResponseModel response)
		{
			var request = new ApiDestinationClientRequestModel();
			request.SetProperties(
				response.CountryId,
				response.Name,
				response.Order);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>3ca0a06d9460bcf51ffff78aae492d96</Hash>
</Codenesium>*/