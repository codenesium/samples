using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public partial interface IMachineRepository
	{
		Task<Machine> Create(Machine item);

		Task Update(Machine item);

		Task Delete(int id);

		Task<Machine> Get(int id);

		Task<List<Machine>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Link>> Links(int assignedMachineId, int limit = int.MaxValue, int offset = 0);

		Task<List<MachineRefTeam>> MachineRefTeams(int machineId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>adbb676069f783bfa8ac455931a44bdb</Hash>
</Codenesium>*/