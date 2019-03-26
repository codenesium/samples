using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IVehicleCapabilittyService
	{
		Task<CreateResponse<ApiVehicleCapabilittyServerResponseModel>> Create(
			ApiVehicleCapabilittyServerRequestModel model);

		Task<UpdateResponse<ApiVehicleCapabilittyServerResponseModel>> Update(int vehicleId,
		                                                                       ApiVehicleCapabilittyServerRequestModel model);

		Task<ActionResponse> Delete(int vehicleId);

		Task<ApiVehicleCapabilittyServerResponseModel> Get(int vehicleId);

		Task<List<ApiVehicleCapabilittyServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>a48113e92239d64f25cf92bba48dfd72</Hash>
</Codenesium>*/