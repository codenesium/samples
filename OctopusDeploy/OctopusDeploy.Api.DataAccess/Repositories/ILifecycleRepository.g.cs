using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public interface ILifecycleRepository
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
    <Hash>d45a6e6b7bc9c65c8d2f031c36c3d234</Hash>
</Codenesium>*/