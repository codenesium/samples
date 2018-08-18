using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface ITenantVariableRepository
	{
		Task<TenantVariable> Create(TenantVariable item);

		Task Update(TenantVariable item);

		Task Delete(string id);

		Task<TenantVariable> Get(string id);

		Task<List<TenantVariable>> All(int limit = int.MaxValue, int offset = 0);

		Task<TenantVariable> ByTenantIdOwnerIdEnvironmentIdVariableTemplateId(string tenantId, string ownerId, string environmentId, string variableTemplateId);

		Task<List<TenantVariable>> ByTenantId(string tenantId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2d325b0d39c88042c325ea5bb72ae910</Hash>
</Codenesium>*/