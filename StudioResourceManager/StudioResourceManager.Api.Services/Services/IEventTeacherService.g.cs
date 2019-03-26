using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IEventTeacherService
	{
		Task<CreateResponse<ApiEventTeacherServerResponseModel>> Create(
			ApiEventTeacherServerRequestModel model);

		Task<UpdateResponse<ApiEventTeacherServerResponseModel>> Update(int id,
		                                                                 ApiEventTeacherServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiEventTeacherServerResponseModel> Get(int id);

		Task<List<ApiEventTeacherServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiEventTeacherServerResponseModel>> ById(int id, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventTeacherServerResponseModel>> ByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7ba9fa7adb13f7c70a9b59d6c8f927dc</Hash>
</Codenesium>*/