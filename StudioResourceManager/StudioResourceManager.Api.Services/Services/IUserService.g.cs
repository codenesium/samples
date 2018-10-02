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

		Task<List<ApiAdminResponseModel>> Admins(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStudentResponseModel>> Students(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherResponseModel>> Teachers(int userId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0846d7ec8da1e008c00eb8529fde0f48</Hash>
</Codenesium>*/