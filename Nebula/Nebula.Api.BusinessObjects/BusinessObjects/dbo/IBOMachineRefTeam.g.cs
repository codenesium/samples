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

		POCOMachineRefTeam Get(int id);

		List<POCOMachineRefTeam> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2116a799d6cdc5084544dfc0b9ca8f2f</Hash>
</Codenesium>*/