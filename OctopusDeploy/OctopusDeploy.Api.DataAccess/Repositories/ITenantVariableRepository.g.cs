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

                Task<List<TenantVariable>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<TenantVariable> GetTenantIdOwnerIdEnvironmentIdVariableTemplateId(string tenantId, string ownerId, string environmentId, string variableTemplateId);
                Task<List<TenantVariable>> GetTenantId(string tenantId);
        }
}

/*<Codenesium>
    <Hash>aa8b39079335c4fdcfbead91b5ba0353</Hash>
</Codenesium>*/