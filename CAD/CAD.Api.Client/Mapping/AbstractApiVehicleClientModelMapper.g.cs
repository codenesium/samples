using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiVehicleModelMapper
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
    <Hash>f52c35fc2422313a2911d2ed2f3816a6</Hash>
</Codenesium>*/