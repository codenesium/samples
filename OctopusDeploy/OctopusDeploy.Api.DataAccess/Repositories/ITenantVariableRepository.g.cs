using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface ITenantVariableRepository
        {
                Task<TenantVariable> Create(TenantVariable item);

                Task Update(TenantVariable item);

                Task Delete(string id);

                Task<TenantVariable> Get(string id);

                Task<List<TenantVariable>> All(int limit = int.MaxValue, int offset = 0);

                Task<TenantVariable> GetTenantIdOwnerIdEnvironmentIdVariableTemplateId(string tenantId, string ownerId, string environmentId, string variableTemplateId);

                Task<List<TenantVariable>> GetTenantId(string tenantId);
        }
}

/*<Codenesium>
    <Hash>f60e240fff9b835bfed66021794506e1</Hash>
</Codenesium>*/