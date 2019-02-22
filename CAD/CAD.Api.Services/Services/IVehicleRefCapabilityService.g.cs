using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IVehicleRefCapabilityService
	{
		Task<CreateResponse<ApiVehicleRefCapabilityServerResponseModel>> Create(
			ApiVehicleRefCapabilityServerRequestModel model);

		Task<UpdateResponse<ApiVehicleRefCapabilityServerResponseModel>> Update(int id,
		                                                                         ApiVehicleRefCapabilityServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiVehicleRefCapabilityServerResponseModel> Get(int id);

		Task<List<ApiVehicleRefCapabilityServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>6cd682fd26910b82135bdd9a1ef8eb13</Hash>
</Codenesium>*/