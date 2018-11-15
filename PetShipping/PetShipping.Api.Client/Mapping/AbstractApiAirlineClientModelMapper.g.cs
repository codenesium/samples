using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public abstract class AbstractApiAirlineModelMapper
	{
		public virtual ApiAirlineClientResponseModel MapClientRequestToResponse(
			int id,
			ApiAirlineClientRequestModel request)
		{
			var response = new ApiAirlineClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiAirlineClientRequestModel MapClientResponseToRequest(
			ApiAirlineClientResponseModel response)
		{
			var request = new ApiAirlineClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>37c8fc49b02b1f9f1f62e96dd39dad24</Hash>
</Codenesium>*/