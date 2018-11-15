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
	}
}

/*<Codenesium>
    <Hash>f67770551d2f4d85600acab2e451f4c9</Hash>
</Codenesium>*/