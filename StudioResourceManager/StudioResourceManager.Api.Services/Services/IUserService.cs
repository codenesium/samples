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

		Task<List<ApiUserServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiAdminServerResponseModel>> AdminsByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStudentServerResponseModel>> StudentsByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherServerResponseModel>> TeachersByUserId(int userId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0926c9426036e51c8caf0307c0598248</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/