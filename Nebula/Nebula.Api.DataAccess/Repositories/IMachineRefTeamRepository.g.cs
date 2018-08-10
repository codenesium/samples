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
    <Hash>f0f91422d6c202b211a27484e189880b</Hash>
</Codenesium>*/