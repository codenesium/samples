using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public interface IStudioService
	{
		Task<CreateResponse<ApiStudioResponseModel>> Create(
			ApiStudioRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiStudioRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiStudioResponseModel> Get(int id);

		Task<List<ApiStudioResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0b91930f21e60bf836d7a8b275462998</Hash>
</Codenesium>*/