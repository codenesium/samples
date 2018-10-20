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

		Task<Machine> ByMachineGuid(Guid machineGuid);

		Task<List<Link>> LinksByAssignedMachineId(int assignedMachineId, int limit = int.MaxValue, int offset = 0);

		Task<List<Machine>> ByTeamId(int teamId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d02758629d9bb030f5c54b2429acce92</Hash>
</Codenesium>*/