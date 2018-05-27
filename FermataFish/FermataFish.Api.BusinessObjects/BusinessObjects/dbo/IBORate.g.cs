using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBORate
	{
		Task<CreateResponse<ApiRateResponseModel>> Create(
			ApiRateRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiRateRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiRateResponseModel> Get(int id);

		Task<List<ApiRateResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f982f5c4a2d0f07781ab7609f18294e8</Hash>
</Codenesium>*/