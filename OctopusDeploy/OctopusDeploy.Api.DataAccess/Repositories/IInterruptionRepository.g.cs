using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IInterruptionRepository
	{
		Task<Interruption> Create(Interruption item);

		Task Update(Interruption item);

		Task Delete(string id);

		Task<Interruption> Get(string id);

		Task<List<Interruption>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Interruption>> ByTenantId(string tenantId);
	}
}

/*<Codenesium>
    <Hash>7c441bb6623360e02bdb96737fd53c43</Hash>
</Codenesium>*/