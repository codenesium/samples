using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IMachinePolicyRepository
	{
		Task<MachinePolicy> Create(MachinePolicy item);

		Task Update(MachinePolicy item);

		Task Delete(string id);

		Task<MachinePolicy> Get(string id);

		Task<List<MachinePolicy>> All(int limit = int.MaxValue, int offset = 0);

		Task<MachinePolicy> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>2baf073a8b0dedd7aa75ef6a5841fda5</Hash>
</Codenesium>*/