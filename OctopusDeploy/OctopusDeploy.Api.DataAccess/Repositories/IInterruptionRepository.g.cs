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

                Task<List<Interruption>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<Interruption>> GetTenantId(string tenantId);
        }
}

/*<Codenesium>
    <Hash>982584c61c3011f0f9f190670fff1803</Hash>
</Codenesium>*/