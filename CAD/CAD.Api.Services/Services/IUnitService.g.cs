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

		Task<List<ApiUnitOfficerServerResponseModel>> UnitOfficersByUnitId(int unitId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiCallAssignmentServerResponseModel>> CallAssignmentsByUnitId(int unitId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8d08af169b26a21b02fbe061ad0e15c2</Hash>
</Codenesium>*/