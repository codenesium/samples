using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IMachineRepository
        {
                Task<Machine> Create(Machine item);

                Task Update(Machine item);

                Task Delete(string id);

                Task<Machine> Get(string id);

                Task<List<Machine>> All(int limit = int.MaxValue, int offset = 0);

                Task<Machine> GetName(string name);

                Task<List<Machine>> GetMachinePolicyId(string machinePolicyId);
        }
}

/*<Codenesium>
    <Hash>dfb40bd2b22a9d85f367e89621505ff1</Hash>
</Codenesium>*/