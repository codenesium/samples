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

                Task<List<Machine>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<Machine> GetName(string name);
                Task<List<Machine>> GetMachinePolicyId(string machinePolicyId);
        }
}

/*<Codenesium>
    <Hash>fb54cd0f1b9b354544608615474950ad</Hash>
</Codenesium>*/