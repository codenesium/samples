using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IMachineRefTeamRepository
	{
		Task<DTOMachineRefTeam> Create(DTOMachineRefTeam dto);

		Task Update(int id,
		            DTOMachineRefTeam dto);

		Task Delete(int id);

		Task<DTOMachineRefTeam> Get(int id);

		Task<List<DTOMachineRefTeam>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5df548fd5351571160a59e1b7ae20509</Hash>
</Codenesium>*/