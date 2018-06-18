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

                Task<List<WorkerTaskLease>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>fdc300f3fa77a112628b5df22c6fb205</Hash>
</Codenesium>*/