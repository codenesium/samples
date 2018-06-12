using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IMachinePolicyRepository
        {
                Task<MachinePolicy> Create(MachinePolicy item);

                Task Update(MachinePolicy item);

                Task Delete(string id);

                Task<MachinePolicy> Get(string id);

                Task<List<MachinePolicy>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<MachinePolicy> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>b7299b8ab5d0e7132a54c87f94f8e03a</Hash>
</Codenesium>*/