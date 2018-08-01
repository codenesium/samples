using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public interface IMutexRepository
	{
		Task<Mutex> Create(Mutex item);

		Task Update(Mutex item);

		Task Delete(string id);

		Task<Mutex> Get(string id);

		Task<List<Mutex>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a4e8704d55b5f3694841e6c5ebbb0776</Hash>
</Codenesium>*/