using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IWorkerRepository
	{
		Task<Worker> Create(Worker item);

		Task Update(Worker item);

		Task Delete(string id);

		Task<Worker> Get(string id);

		Task<List<Worker>> All(int limit = int.MaxValue, int offset = 0);

		Task<Worker> ByName(string name);

		Task<List<Worker>> ByMachinePolicyId(string machinePolicyId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>eabb609634fb1ef2ce9b2b587bf69f47</Hash>
</Codenesium>*/