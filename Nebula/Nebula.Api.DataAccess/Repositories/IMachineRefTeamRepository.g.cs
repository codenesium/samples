using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public partial interface IMachineRefTeamRepository
	{
		Task<MachineRefTeam> Create(MachineRefTeam item);

		Task Update(MachineRefTeam item);

		Task Delete(int id);

		Task<MachineRefTeam> Get(int id);

		Task<List<MachineRefTeam>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Machine> MachineByMachineId(int machineId);

		Task<Team> TeamByTeamId(int teamId);
	}
}

/*<Codenesium>
    <Hash>28f869ac5432b20f60bf6b50f2c948d2</Hash>
</Codenesium>*/