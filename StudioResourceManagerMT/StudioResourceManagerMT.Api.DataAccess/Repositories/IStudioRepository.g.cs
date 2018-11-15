using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial interface IStudioRepository
	{
		Task<Studio> Create(Studio item);

		Task Update(Studio item);

		Task Delete(int id);

		Task<Studio> Get(int id);

		Task<List<Studio>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7fc0391d58d2cf426c462dfc08651833</Hash>
</Codenesium>*/