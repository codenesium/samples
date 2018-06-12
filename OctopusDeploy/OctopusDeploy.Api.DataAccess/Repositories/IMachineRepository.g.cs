using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IMachineRepository
        {
                Task<Machine> Create(Machine item);

                Task Update(Machine item);

                Task Delete(string id);

                Task<Machine> Get(string id);

                Task<List<Machine>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<Machine> GetName(string name);
                Task<List<Machine>> GetMachinePolicyId(string machinePolicyId);
        }
}

/*<Codenesium>
    <Hash>3457dfe6ee6c5e1e84cba63d581061ef</Hash>
</Codenesium>*/