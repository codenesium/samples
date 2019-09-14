using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public class ApiCityModelMapper : IApiCityModelMapper
	{
		public virtual ApiCityClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCityClientRequestModel request)
		{
			var response = new ApiCityClientResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.ProvinceId);
			return response;
		}

		public virtual ApiCityClientRequestModel MapClientResponseToRequest(
			ApiCityClientResponseModel response)
		{
			var request = new ApiCityClientRequestModel();
			request.SetProperties(
				response.Name,
				response.ProvinceId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>284a39c8cea53fd598b91a10e564bc7b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/