using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IVehicleCapabilitiesService
	{
		Task<CreateResponse<ApiVehicleCapabilitiesServerResponseModel>> Create(
			ApiVehicleCapabilitiesServerRequestModel model);

		Task<UpdateResponse<ApiVehicleCapabilitiesServerResponseModel>> Update(int vehicleId,
		                                                                        ApiVehicleCapabilitiesServerRequestModel model);

		Task<ActionResponse> Delete(int vehicleId);

		Task<ApiVehicleCapabilitiesServerResponseModel> Get(int vehicleId);

		Task<List<ApiVehicleCapabilitiesServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>e20b7da242342e156f2e7b90d01c65e2</Hash>
</Codenesium>*/