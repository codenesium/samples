using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IUserService
	{
		Task<CreateResponse<ApiUserResponseModel>> Create(
			ApiUserRequestModel model);

		Task<UpdateResponse<ApiUserResponseModel>> Update(int id,
		                                                   ApiUserRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiUserResponseModel> Get(int id);

		Task<List<ApiUserResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiAdminResponseModel>> AdminsByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStudentResponseModel>> StudentsByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherResponseModel>> TeachersByUserId(int userId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c9742b5090099d05ba08274e3b364783</Hash>
</Codenesium>*/