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

		Task<POCOTeam> Name(string name);
	}
}

/*<Codenesium>
    <Hash>e81fc09a8b2ca3d2666ed6f914237d88</Hash>
</Codenesium>*/