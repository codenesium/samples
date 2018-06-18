using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IWorkerPoolRepository
        {
                Task<WorkerPool> Create(WorkerPool item);

                Task Update(WorkerPool item);

                Task Delete(string id);

                Task<WorkerPool> Get(string id);

                Task<List<WorkerPool>> All(int limit = int.MaxValue, int offset = 0);

                Task<WorkerPool> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>6a8a00a045eb283c487c501cc6d279b5</Hash>
</Codenesium>*/