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

		Task<List<ApiVehicleCapabilittyServerResponseModel>> VehicleCapabilitiesByVehicleId(int vehicleId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiVehicleServerResponseModel>> ByOfficerId(int vehicleId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f5c77468f55569964f6b825f8a539c32</Hash>
</Codenesium>*/