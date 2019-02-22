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
	}
}

/*<Codenesium>
    <Hash>fe5b36db172fc1bd13a65de5697fe66a</Hash>
</Codenesium>*/