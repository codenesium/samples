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
		Task<CreateResponse<POCOTeam>> Create(
			ApiTeamModel model);

		Task<ActionResponse> Update(int id,
		                            ApiTeamModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOTeam> Get(int id);

		Task<List<POCOTeam>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOTeam> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>4c21b02ca73cde01da10528081c08921</Hash>
</Codenesium>*/