using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public interface IMachineRepository
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
    <Hash>ad1c7edccd670d11015f870118c79a32</Hash>
</Codenesium>*/