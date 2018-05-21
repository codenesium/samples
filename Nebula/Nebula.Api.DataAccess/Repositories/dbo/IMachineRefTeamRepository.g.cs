using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IMachineRefTeamRepository
	{
		Task<POCOMachineRefTeam> Create(ApiMachineRefTeamModel model);

		Task Update(int id,
		            ApiMachineRefTeamModel model);

		Task Delete(int id);

		Task<POCOMachineRefTeam> Get(int id);

		Task<List<POCOMachineRefTeam>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>24b7a527b3e4c0975d4e375741f59c27</Hash>
</Codenesium>*/