using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public abstract class AbstractApiLocationModelMapper
	{
		public virtual ApiLocationClientResponseModel MapClientRequestToResponse(
			int locationId,
			ApiLocationClientRequestModel request)
		{
			var response = new ApiLocationClientResponseModel();
			response.SetProperties(locationId,
			                       request.GpsLat,
			                       request.GpsLong,
			                       request.LocationName);
			return response;
		}

		public virtual ApiLocationClientRequestModel MapClientResponseToRequest(
			ApiLocationClientResponseModel response)
		{
			var request = new ApiLocationClientRequestModel();
			request.SetProperties(
				response.GpsLat,
				response.GpsLong,
				response.LocationName);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>0a22f376ba6a49e661278d745644309e</Hash>
</Codenesium>*/