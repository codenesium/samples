using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public class ApiLocationModelMapper : IApiLocationModelMapper
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
    <Hash>bc2a12ed24f6c1179418821033e4f9c5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/