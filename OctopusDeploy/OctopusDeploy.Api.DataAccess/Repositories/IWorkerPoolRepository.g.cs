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

                Task<List<WorkerPool>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<WorkerPool> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>59d4b0786a6449795bd4ac9dafdd70c1</Hash>
</Codenesium>*/