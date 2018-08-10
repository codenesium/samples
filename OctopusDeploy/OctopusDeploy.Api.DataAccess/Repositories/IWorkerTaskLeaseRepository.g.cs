using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IWorkerTaskLeaseRepository
	{
		Task<WorkerTaskLease> Create(WorkerTaskLease item);

		Task Update(WorkerTaskLease item);

		Task Delete(string id);

		Task<WorkerTaskLease> Get(string id);

		Task<List<WorkerTaskLease>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>20a5ec5ae9b7ca4bb765708c99b2382e</Hash>
</Codenesium>*/