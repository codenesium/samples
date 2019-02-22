using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiVehicleOfficerModelMapper
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
    <Hash>298e26bf1680f66c95c1d05517174ea2</Hash>
</Codenesium>*/