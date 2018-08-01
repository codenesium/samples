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

		Task<List<Interruption>> ByTenantId(string tenantId);
	}
}

/*<Codenesium>
    <Hash>2eba2f8e00dfea2f4ad6513d9633d87d</Hash>
</Codenesium>*/