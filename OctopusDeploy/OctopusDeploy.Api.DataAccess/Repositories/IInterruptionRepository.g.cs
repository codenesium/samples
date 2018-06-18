using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IInterruptionRepository
        {
                Task<Interruption> Create(Interruption item);

                Task Update(Interruption item);

                Task Delete(string id);

                Task<Interruption> Get(string id);

                Task<List<Interruption>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Interruption>> GetTenantId(string tenantId);
        }
}

/*<Codenesium>
    <Hash>d39ad3717a73c33fdf5845b5d5ccaa21</Hash>
</Codenesium>*/