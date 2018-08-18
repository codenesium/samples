using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IProxyRepository
	{
		Task<Proxy> Create(Proxy item);

		Task Update(Proxy item);

		Task Delete(string id);

		Task<Proxy> Get(string id);

		Task<List<Proxy>> All(int limit = int.MaxValue, int offset = 0);

		Task<Proxy> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>d2de00a71df0dbc6117bcd409a86121d</Hash>
</Codenesium>*/