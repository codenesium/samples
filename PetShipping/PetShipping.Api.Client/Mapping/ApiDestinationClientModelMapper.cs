using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public class ApiDestinationModelMapper : IApiDestinationModelMapper
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
    <Hash>a50b185b6a233bd96dd37639839e26e5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/