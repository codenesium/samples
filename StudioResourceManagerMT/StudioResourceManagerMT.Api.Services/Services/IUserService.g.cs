using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IUserService
	{
		Task<CreateResponse<ApiUserServerResponseModel>> Create(
			ApiUserServerRequestModel model);

		Task<UpdateResponse<ApiUserServerResponseModel>> Update(int id,
		                                                         ApiUserServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiUserServerResponseModel> Get(int id);

		Task<List<ApiUserServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiAdminServerResponseModel>> AdminsByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStudentServerResponseModel>> StudentsByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherServerResponseModel>> TeachersByUserId(int userId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>4dc00a50e00c95c616f1b1e8d48efbc3</Hash>
</Codenesium>*/