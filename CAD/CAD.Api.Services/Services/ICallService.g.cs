using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface ICallService
	{
		Task<CreateResponse<ApiCallServerResponseModel>> Create(
			ApiCallServerRequestModel model);

		Task<UpdateResponse<ApiCallServerResponseModel>> Update(int id,
		                                                         ApiCallServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCallServerResponseModel> Get(int id);

		Task<List<ApiCallServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiNoteServerResponseModel>> NotesByCallId(int callId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiCallAssignmentServerResponseModel>> CallAssignmentsByCallId(int callId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>aa13285904c30be91ff35f9e765dc369</Hash>
</Codenesium>*/