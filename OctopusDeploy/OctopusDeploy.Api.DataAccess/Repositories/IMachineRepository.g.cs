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

		Task<List<Machine>> ByMachinePolicyId(string machinePolicyId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>acb674b1d7a15545b3d3f08211167ef0</Hash>
</Codenesium>*/