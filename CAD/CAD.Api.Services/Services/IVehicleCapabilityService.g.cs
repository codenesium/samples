using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IVehicleCapabilityService
	{
		Task<CreateResponse<ApiVehicleCapabilityServerResponseModel>> Create(
			ApiVehicleCapabilityServerRequestModel model);

		Task<UpdateResponse<ApiVehicleCapabilityServerResponseModel>> Update(int id,
		                                                                      ApiVehicleCapabilityServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiVehicleCapabilityServerResponseModel> Get(int id);

		Task<List<ApiVehicleCapabilityServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiVehicleRefCapabilityServerResponseModel>> VehicleRefCapabilitiesByVehicleCapabilityId(int vehicleCapabilityId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a12305149618fb7033308ffdaf9674ab</Hash>
</Codenesium>*/