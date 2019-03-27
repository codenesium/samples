using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IVehicleOfficerService
	{
		Task<CreateResponse<ApiVehicleOfficerServerResponseModel>> Create(
			ApiVehicleOfficerServerRequestModel model);

		Task<UpdateResponse<ApiVehicleOfficerServerResponseModel>> Update(int id,
		                                                                   ApiVehicleOfficerServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiVehicleOfficerServerResponseModel> Get(int id);

		Task<List<ApiVehicleOfficerServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiVehicleOfficerServerResponseModel>> ByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>29aee02997bde4c23552f228243f87c9</Hash>
</Codenesium>*/