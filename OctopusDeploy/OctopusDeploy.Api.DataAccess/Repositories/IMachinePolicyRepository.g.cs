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

                Task<List<MachinePolicy>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<MachinePolicy> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>446faa2ba53e0a28503130ee690272b3</Hash>
</Codenesium>*/