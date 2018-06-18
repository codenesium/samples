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

                Task<List<TenantVariable>> All(int limit = int.MaxValue, int offset = 0);

                Task<TenantVariable> GetTenantIdOwnerIdEnvironmentIdVariableTemplateId(string tenantId, string ownerId, string environmentId, string variableTemplateId);
                Task<List<TenantVariable>> GetTenantId(string tenantId);
        }
}

/*<Codenesium>
    <Hash>819ed3a40645490f572722bbee710ecc</Hash>
</Codenesium>*/