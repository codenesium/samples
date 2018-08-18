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

		Task<List<Tenant>> ByDataVersion(byte[] dataVersion, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3b2688fe1d9dbfe43594d49376576190</Hash>
</Codenesium>*/