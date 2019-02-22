using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IVehicleService
	{
		Task<CreateResponse<ApiVehicleServerResponseModel>> Create(
			ApiVehicleServerRequestModel model);

		Task<UpdateResponse<ApiVehicleServerResponseModel>> Update(int id,
		                                                            ApiVehicleServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiVehicleServerResponseModel> Get(int id);

		Task<List<ApiVehicleServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiVehicleOfficerServerResponseModel>> VehicleOfficersByVehicleId(int vehicleId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiVehicleRefCapabilityServerResponseModel>> VehicleRefCapabilitiesByVehicleId(int vehicleId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3ccee6b10fef7076aeb2d69c0f7f1706</Hash>
</Codenesium>*/