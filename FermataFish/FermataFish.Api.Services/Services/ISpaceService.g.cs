using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public interface ISpaceService
	{
		Task<CreateResponse<ApiSpaceResponseModel>> Create(
			ApiSpaceRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiSpaceRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSpaceResponseModel> Get(int id);

		Task<List<ApiSpaceResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d44d89e343250fb90e88f120e3c2251c</Hash>
</Codenesium>*/