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

                Task<List<Interruption>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Interruption>> GetTenantId(string tenantId);
        }
}

/*<Codenesium>
    <Hash>d15520bfecd7ac68ed481b2e49002bc2</Hash>
</Codenesium>*/