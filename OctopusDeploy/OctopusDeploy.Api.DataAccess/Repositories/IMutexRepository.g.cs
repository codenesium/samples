using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IMutexRepository
	{
		Task<Mutex> Create(Mutex item);

		Task Update(Mutex item);

		Task Delete(string id);

		Task<Mutex> Get(string id);

		Task<List<Mutex>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>eab6bb0129b924c495780b874c9b5323</Hash>
</Codenesium>*/