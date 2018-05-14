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
			MachineRefTeamModel model);

		Task<ActionResponse> Update(int id,
		                            MachineRefTeamModel model);

		Task<ActionResponse> Delete(int id);

		POCOMachineRefTeam Get(int id);

		List<POCOMachineRefTeam> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>18ec00d9107927700af248903f0517ce</Hash>
</Codenesium>*/