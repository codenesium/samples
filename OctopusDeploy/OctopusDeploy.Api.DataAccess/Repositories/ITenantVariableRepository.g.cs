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

                Task<TenantVariable> ByTenantIdOwnerIdEnvironmentIdVariableTemplateId(string tenantId, string ownerId, string environmentId, string variableTemplateId);

                Task<List<TenantVariable>> ByTenantId(string tenantId);
        }
}

/*<Codenesium>
    <Hash>1d8767e1181b8f4ced1e9ed67656595f</Hash>
</Codenesium>*/