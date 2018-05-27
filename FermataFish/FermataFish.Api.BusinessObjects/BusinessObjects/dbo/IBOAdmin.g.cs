using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOAdmin
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
    <Hash>987dfcd0a6ae8c6b7d51586112593c9a</Hash>
</Codenesium>*/