using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IUserService
	{
		Task<CreateResponse<ApiUserServerResponseModel>> Create(
			ApiUserServerRequestModel model);

		Task<UpdateResponse<ApiUserServerResponseModel>> Update(int id,
		                                                         ApiUserServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiUserServerResponseModel> Get(int id);

		Task<List<ApiUserServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiAdminServerResponseModel>> AdminsByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStudentServerResponseModel>> StudentsByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherServerResponseModel>> TeachersByUserId(int userId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a5555a628a9278c0cdd5604b703e8972</Hash>
</Codenesium>*/