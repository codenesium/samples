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
    <Hash>07fe3bac6a396211a3817ab13405fb7b</Hash>
</Codenesium>*/