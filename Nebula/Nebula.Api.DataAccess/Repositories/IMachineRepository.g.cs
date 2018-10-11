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

		Task<List<Link>> Links(int assignedMachineId, int limit = int.MaxValue, int offset = 0);

		Task<List<Machine>> ByMachineId(int machineId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a7b62e326a0a6296cc71435930a3109f</Hash>
</Codenesium>*/