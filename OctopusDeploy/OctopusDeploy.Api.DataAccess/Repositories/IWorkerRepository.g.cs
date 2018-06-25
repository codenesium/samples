using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IWorkerRepository
        {
                Task<Worker> Create(Worker item);

                Task Update(Worker item);

                Task Delete(string id);

                Task<Worker> Get(string id);

                Task<List<Worker>> All(int limit = int.MaxValue, int offset = 0);

                Task<Worker> ByName(string name);

                Task<List<Worker>> ByMachinePolicyId(string machinePolicyId);
        }
}

/*<Codenesium>
    <Hash>bce93839fb4c9d59ed1e1a5bfaf10afa</Hash>
</Codenesium>*/