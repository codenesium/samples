using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public class ApiVehicleOfficerModelMapper : IApiVehicleOfficerModelMapper
	{
		public virtual ApiVehicleOfficerClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVehicleOfficerClientRequestModel request)
		{
			var response = new ApiVehicleOfficerClientResponseModel();
			response.SetProperties(id,
			                       request.OfficerId,
			                       request.VehicleId);
			return response;
		}

		public virtual ApiVehicleOfficerClientRequestModel MapClientResponseToRequest(
			ApiVehicleOfficerClientResponseModel response)
		{
			var request = new ApiVehicleOfficerClientRequestModel();
			request.SetProperties(
				response.OfficerId,
				response.VehicleId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>13b94c96de1064dc15add89e0274528e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/