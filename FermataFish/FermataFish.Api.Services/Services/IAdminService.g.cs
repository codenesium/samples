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
    <Hash>855ceb2f466789667a8ac1eee5ae53b3</Hash>
</Codenesium>*/