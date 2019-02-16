using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IAdminService
	{
		Task<CreateResponse<ApiAdminServerResponseModel>> Create(
			ApiAdminServerRequestModel model);

		Task<UpdateResponse<ApiAdminServerResponseModel>> Update(int id,
		                                                          ApiAdminServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiAdminServerResponseModel> Get(int id);

		Task<List<ApiAdminServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiAdminServerResponseModel>> ByUserId(int userId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>fff660e3ea60bd93462b6b6ef4e28946</Hash>
</Codenesium>*/