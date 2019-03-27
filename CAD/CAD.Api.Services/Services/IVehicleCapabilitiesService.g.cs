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

		Task<UpdateResponse<ApiVehicleCapabilitiesServerResponseModel>> Update(int id,
		                                                                        ApiVehicleCapabilitiesServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiVehicleCapabilitiesServerResponseModel> Get(int id);

		Task<List<ApiVehicleCapabilitiesServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>000a60917742ff19f0aba8bc61026c20</Hash>
</Codenesium>*/