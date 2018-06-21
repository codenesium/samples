using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>2b0c53236ecdf235cfc71932e1bae14f</Hash>
</Codenesium>*/