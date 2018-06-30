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
    <Hash>c1f39bed3be1e8312c795f31bafd4199</Hash>
</Codenesium>*/