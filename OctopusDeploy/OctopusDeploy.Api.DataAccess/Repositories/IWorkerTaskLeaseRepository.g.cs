using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IWorkerTaskLeaseRepository
        {
                Task<WorkerTaskLease> Create(WorkerTaskLease item);

                Task Update(WorkerTaskLease item);

                Task Delete(string id);

                Task<WorkerTaskLease> Get(string id);

                Task<List<WorkerTaskLease>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>301d185cf0f9df6a9c03e8bad7f25d4c</Hash>
</Codenesium>*/