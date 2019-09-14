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

		Task<List<ApiVehicleCapabilitiesServerResponseModel>> VehicleCapabilitiesByVehicleId(int vehicleId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiVehicleOfficerServerResponseModel>> VehicleOfficersByVehicleId(int vehicleId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>bd2f5462ba9e025f71e552d4d0a3db6d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/