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

                Task<List<Worker>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<Worker> GetName(string name);
                Task<List<Worker>> GetMachinePolicyId(string machinePolicyId);
        }
}

/*<Codenesium>
    <Hash>d331e26d6a91a9b704aa4d2d497ff7c0</Hash>
</Codenesium>*/