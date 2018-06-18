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

                Task<List<Machine>> All(int limit = int.MaxValue, int offset = 0);

                Task<Machine> GetName(string name);
                Task<List<Machine>> GetMachinePolicyId(string machinePolicyId);
        }
}

/*<Codenesium>
    <Hash>f02bfae97b0c5bf71ad47f11da759bef</Hash>
</Codenesium>*/