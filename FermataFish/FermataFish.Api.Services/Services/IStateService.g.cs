using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public interface IStateService
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
    <Hash>cb015d2221e00d9a865b0770d423162a</Hash>
</Codenesium>*/