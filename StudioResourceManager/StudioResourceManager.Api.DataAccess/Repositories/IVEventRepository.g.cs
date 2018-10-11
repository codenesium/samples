using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial interface IVEventRepository
	{
		Task<VEvent> Get(int id);

		Task<List<VEvent>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d55942211c7ad2b329e198263a3139c6</Hash>
</Codenesium>*/