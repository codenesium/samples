using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IMachineRepository
	{
		Task<Machine> Create(Machine item);

		Task Update(Machine item);

		Task Delete(string id);

		Task<Machine> Get(string id);

		Task<List<Machine>> All(int limit = int.MaxValue, int offset = 0);

		Task<Machine> ByName(string name);

		Task<List<Machine>> ByMachinePolicyId(string machinePolicyId);
	}
}

/*<Codenesium>
    <Hash>5c8df6a43e98c984370bc6f6f3a773fa</Hash>
</Codenesium>*/