using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IWorkerPoolRepository
	{
		Task<WorkerPool> Create(WorkerPool item);

		Task Update(WorkerPool item);

		Task Delete(string id);

		Task<WorkerPool> Get(string id);

		Task<List<WorkerPool>> All(int limit = int.MaxValue, int offset = 0);

		Task<WorkerPool> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>c564917ff801acf17dae4a9938130180</Hash>
</Codenesium>*/