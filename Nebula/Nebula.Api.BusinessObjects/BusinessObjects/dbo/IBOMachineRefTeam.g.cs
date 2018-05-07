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
		Task<CreateResponse<int>> Create(
			MachineRefTeamModel model);

		Task<ActionResponse> Update(int id,
		                            MachineRefTeamModel model);

		Task<ActionResponse> Delete(int id);

		POCOMachineRefTeam Get(int id);

		List<POCOMachineRefTeam> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>adf9b9fd2582559848b1e63e98efde04</Hash>
</Codenesium>*/