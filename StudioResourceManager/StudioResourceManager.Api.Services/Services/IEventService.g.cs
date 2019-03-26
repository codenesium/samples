using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IEventService
	{
		Task<CreateResponse<ApiEventServerResponseModel>> Create(
			ApiEventServerRequestModel model);

		Task<UpdateResponse<ApiEventServerResponseModel>> Update(int id,
		                                                          ApiEventServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiEventServerResponseModel> Get(int id);

		Task<List<ApiEventServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiEventServerResponseModel>> ByEventStatusId(int eventStatusId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventStudentServerResponseModel>> EventStudentsByEventId(int eventId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventTeacherServerResponseModel>> EventTeachersById(int id, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>9f0da5e2a9cf0aa160de2a509c30ff94</Hash>
</Codenesium>*/