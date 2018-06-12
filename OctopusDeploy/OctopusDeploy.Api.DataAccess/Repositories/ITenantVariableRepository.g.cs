using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface ITenantVariableRepository
        {
                Task<TenantVariable> Create(TenantVariable item);

                Task Update(TenantVariable item);

                Task Delete(string id);

                Task<TenantVariable> Get(string id);

                Task<List<TenantVariable>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<TenantVariable> GetTenantIdOwnerIdEnvironmentIdVariableTemplateId(string tenantId, string ownerId, string environmentId, string variableTemplateId);
                Task<List<TenantVariable>> GetTenantId(string tenantId);
        }
}

/*<Codenesium>
    <Hash>d3253c3d6a19b12ed01c7cd6434eb121</Hash>
</Codenesium>*/