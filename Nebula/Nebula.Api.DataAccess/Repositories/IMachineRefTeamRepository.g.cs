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

		Task<List<MachineRefTeam>> All(int limit = int.MaxValue, int offset = 0);

		Task<Machine> GetMachine(int machineId);

		Task<Team> GetTeam(int teamId);
	}
}

/*<Codenesium>
    <Hash>a5820681180cb0d892970f345eaf2c42</Hash>
</Codenesium>*/