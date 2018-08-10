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

		Task<List<Lifecycle>> ByDataVersion(byte[] dataVersion);
	}
}

/*<Codenesium>
    <Hash>6219f35cfcad551cbc32a5f151ec0b9e</Hash>
</Codenesium>*/