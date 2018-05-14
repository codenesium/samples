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
			TeamModel model);

		Task<ActionResponse> Update(int id,
		                            TeamModel model);

		Task<ActionResponse> Delete(int id);

		POCOTeam Get(int id);

		List<POCOTeam> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOTeam Name(string name);
	}
}

/*<Codenesium>
    <Hash>4c6cdb55e33d44c1ec9927642e63d556</Hash>
</Codenesium>*/