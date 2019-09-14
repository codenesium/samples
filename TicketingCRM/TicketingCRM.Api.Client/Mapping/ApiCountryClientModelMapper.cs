using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public class ApiCountryModelMapper : IApiCountryModelMapper
	{
		public virtual ApiCountryClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCountryClientRequestModel request)
		{
			var response = new ApiCountryClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiCountryClientRequestModel MapClientResponseToRequest(
			ApiCountryClientResponseModel response)
		{
			var request = new ApiCountryClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>c992740676e2404125b4350ab1c58ec3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/