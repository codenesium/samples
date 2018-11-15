using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IAdminService
	{
		Task<CreateResponse<ApiAdminServerResponseModel>> Create(
			ApiAdminServerRequestModel model);

		Task<UpdateResponse<ApiAdminServerResponseModel>> Update(int id,
		                                                          ApiAdminServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiAdminServerResponseModel> Get(int id);

		Task<List<ApiAdminServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiAdminServerResponseModel>> ByUserId(int userId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>056002e778dad4f35887661b326738ea</Hash>
</Codenesium>*/