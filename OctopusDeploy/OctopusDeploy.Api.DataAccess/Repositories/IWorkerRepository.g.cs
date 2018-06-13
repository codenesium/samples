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

                Task<List<Worker>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<Worker> GetName(string name);
                Task<List<Worker>> GetMachinePolicyId(string machinePolicyId);
        }
}

/*<Codenesium>
    <Hash>ad7e70d31176dff611cd69c6b2d397f9</Hash>
</Codenesium>*/