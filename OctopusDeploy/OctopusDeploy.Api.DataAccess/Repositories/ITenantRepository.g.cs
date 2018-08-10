using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface ITenantRepository
	{
		Task<Tenant> Create(Tenant item);

		Task Update(Tenant item);

		Task Delete(string id);

		Task<Tenant> Get(string id);

		Task<List<Tenant>> All(int limit = int.MaxValue, int offset = 0);

		Task<Tenant> ByName(string name);

		Task<List<Tenant>> ByDataVersion(byte[] dataVersion);
	}
}

/*<Codenesium>
    <Hash>4a1c503bfabd7b20f3043b528a2c11e4</Hash>
</Codenesium>*/