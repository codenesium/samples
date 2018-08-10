using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface IAdminService
	{
		Task<CreateResponse<ApiAdminResponseModel>> Create(
			ApiAdminRequestModel model);

		Task<UpdateResponse<ApiAdminResponseModel>> Update(int id,
		                                                    ApiAdminRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiAdminResponseModel> Get(int id);

		Task<List<ApiAdminResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>07ea377c9e3c04e526081d383569fd52</Hash>
</Codenesium>*/