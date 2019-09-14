using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public class ApiVehicleModelMapper : IApiVehicleModelMapper
	{
		public virtual ApiVehicleClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVehicleClientRequestModel request)
		{
			var response = new ApiVehicleClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiVehicleClientRequestModel MapClientResponseToRequest(
			ApiVehicleClientResponseModel response)
		{
			var request = new ApiVehicleClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>99230c42a0502fc7ea0d0b29ea69f659</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/