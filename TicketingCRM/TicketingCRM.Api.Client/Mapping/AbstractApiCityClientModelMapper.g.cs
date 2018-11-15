using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public abstract class AbstractApiCityModelMapper
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
    <Hash>e976a7d49e45b7a58d60f5daf7ea192a</Hash>
</Codenesium>*/