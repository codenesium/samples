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

		Task<List<Machine>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Machine> ByMachineGuid(Guid machineGuid);

		Task<List<Link>> LinksByAssignedMachineId(int assignedMachineId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>75bc4d75d49b03f2c030dd7a4b0d11da</Hash>
</Codenesium>*/