using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IEventStudentService
	{
		Task<CreateResponse<ApiEventStudentServerResponseModel>> Create(
			ApiEventStudentServerRequestModel model);

		Task<UpdateResponse<ApiEventStudentServerResponseModel>> Update(int id,
		                                                                 ApiEventStudentServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiEventStudentServerResponseModel> Get(int id);

		Task<List<ApiEventStudentServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiEventStudentServerResponseModel>> ByEventId(int eventId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventStudentServerResponseModel>> ByStudentId(int studentId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>5f5d14ae3215b9aa29d3d15c3f34d3e7</Hash>
</Codenesium>*/