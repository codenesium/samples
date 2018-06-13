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

                Task<List<WorkerTaskLease>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>3dc396f164681c30ffa104d9541cd812</Hash>
</Codenesium>*/