using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IVehCapabilityService
	{
		Task<CreateResponse<ApiVehCapabilityServerResponseModel>> Create(
			ApiVehCapabilityServerRequestModel model);

		Task<UpdateResponse<ApiVehCapabilityServerResponseModel>> Update(int id,
		                                                                  ApiVehCapabilityServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiVehCapabilityServerResponseModel> Get(int id);

		Task<List<ApiVehCapabilityServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiVehicleCapabilitiesServerResponseModel>> VehicleCapabilitiesByVehicleCapabilityId(int vehicleCapabilityId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>414d7da81ad0df74259acef56217c51f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/