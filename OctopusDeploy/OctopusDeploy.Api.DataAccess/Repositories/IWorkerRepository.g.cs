using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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
    <Hash>ab9303bdc9b73a7abd2ed58fb89a9fe3</Hash>
</Codenesium>*/