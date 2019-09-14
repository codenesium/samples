using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IUnitService
	{
		Task<CreateResponse<ApiUnitServerResponseModel>> Create(
			ApiUnitServerRequestModel model);

		Task<UpdateResponse<ApiUnitServerResponseModel>> Update(int id,
		                                                         ApiUnitServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiUnitServerResponseModel> Get(int id);

		Task<List<ApiUnitServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiCallAssignmentServerResponseModel>> CallAssignmentsByUnitId(int unitId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiUnitOfficerServerResponseModel>> UnitOfficersByUnitId(int unitId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8397bc1d1b56fc5c0a79a4ae78ad6574</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/