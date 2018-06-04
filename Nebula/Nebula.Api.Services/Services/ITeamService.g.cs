using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public interface ITeamService
	{
		Task<CreateResponse<ApiTeamResponseModel>> Create(
			ApiTeamRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiTeamRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTeamResponseModel> Get(int id);

		Task<List<ApiTeamResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1126bc11b959cf54d28a6d009275f81f</Hash>
</Codenesium>*/