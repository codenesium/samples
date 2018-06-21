using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>79d4f35ce05be05d33d831f7e3699f1d</Hash>
</Codenesium>*/