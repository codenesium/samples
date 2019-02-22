using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface ICallAssignmentService
	{
		Task<CreateResponse<ApiCallAssignmentServerResponseModel>> Create(
			ApiCallAssignmentServerRequestModel model);

		Task<UpdateResponse<ApiCallAssignmentServerResponseModel>> Update(int id,
		                                                                   ApiCallAssignmentServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCallAssignmentServerResponseModel> Get(int id);

		Task<List<ApiCallAssignmentServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiCallAssignmentServerResponseModel>> ByCallId(int callId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiCallAssignmentServerResponseModel>> ByUnitId(int unitId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>6029af69bf47fc71bb4f402ed6df933f</Hash>
</Codenesium>*/