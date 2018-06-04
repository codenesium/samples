using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public interface IAdminService
	{
		Task<CreateResponse<ApiAdminResponseModel>> Create(
			ApiAdminRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiAdminRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiAdminResponseModel> Get(int id);

		Task<List<ApiAdminResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bd43f2177e02de586c8e844d6b79ba99</Hash>
</Codenesium>*/