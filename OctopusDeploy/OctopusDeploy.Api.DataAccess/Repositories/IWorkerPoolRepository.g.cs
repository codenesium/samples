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

                Task<List<WorkerPool>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<WorkerPool> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>e5fc35fa60f162f2a3273ade14acf894</Hash>
</Codenesium>*/