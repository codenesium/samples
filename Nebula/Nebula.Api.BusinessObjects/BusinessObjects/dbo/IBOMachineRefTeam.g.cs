using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOMachineRefTeam
	{
		Task<CreateResponse<POCOMachineRefTeam>> Create(
			ApiMachineRefTeamModel model);

		Task<ActionResponse> Update(int id,
		                            ApiMachineRefTeamModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOMachineRefTeam> Get(int id);

		Task<List<POCOMachineRefTeam>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5854ef55c492b224438a14bcbf3a2327</Hash>
</Codenesium>*/