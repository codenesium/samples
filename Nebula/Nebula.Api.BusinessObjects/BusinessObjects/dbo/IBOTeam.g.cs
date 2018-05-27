using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOTeam
	{
		Task<CreateResponse<ApiTeamResponseModel>> Create(
			ApiTeamRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiTeamRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTeamResponseModel> Get(int id);

		Task<List<ApiTeamResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiTeamResponseModel> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>10429549662104ebc167763d514206f9</Hash>
</Codenesium>*/