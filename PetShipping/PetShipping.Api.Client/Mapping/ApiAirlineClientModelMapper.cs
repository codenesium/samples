using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public class ApiAirlineModelMapper : IApiAirlineModelMapper
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
    <Hash>f17e63a39eab7555102d8ba5a7632484</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/