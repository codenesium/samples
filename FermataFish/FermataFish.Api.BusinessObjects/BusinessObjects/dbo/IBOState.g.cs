using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOState
	{
		Task<CreateResponse<ApiStateResponseModel>> Create(
			ApiStateRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiStateRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiStateResponseModel> Get(int id);

		Task<List<ApiStateResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>fdd06619acd36696d4953f7443fb863e</Hash>
</Codenesium>*/