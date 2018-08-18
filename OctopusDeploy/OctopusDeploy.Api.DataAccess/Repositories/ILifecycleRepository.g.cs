using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface ILifecycleRepository
	{
		Task<Lifecycle> Create(Lifecycle item);

		Task Update(Lifecycle item);

		Task Delete(string id);

		Task<Lifecycle> Get(string id);

		Task<List<Lifecycle>> All(int limit = int.MaxValue, int offset = 0);

		Task<Lifecycle> ByName(string name);

		Task<List<Lifecycle>> ByDataVersion(byte[] dataVersion, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>54c97c9a2bade8fcaf4659990de0af43</Hash>
</Codenesium>*/