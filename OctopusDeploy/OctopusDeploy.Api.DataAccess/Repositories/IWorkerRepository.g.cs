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

                Task<Worker> GetName(string name);

                Task<List<Worker>> GetMachinePolicyId(string machinePolicyId);
        }
}

/*<Codenesium>
    <Hash>dea4b643bdc0f72e750c1db024cc6f16</Hash>
</Codenesium>*/