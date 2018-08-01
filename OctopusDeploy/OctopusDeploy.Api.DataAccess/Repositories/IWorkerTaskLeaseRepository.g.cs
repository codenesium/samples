using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public interface IWorkerTaskLeaseRepository
	{
		Task<WorkerTaskLease> Create(WorkerTaskLease item);

		Task Update(WorkerTaskLease item);

		Task Delete(string id);

		Task<WorkerTaskLease> Get(string id);

		Task<List<WorkerTaskLease>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e4ba823b4f99deadff0045f5ec95993f</Hash>
</Codenesium>*/