using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public partial interface ICompositePrimaryKeyRepository
	{
		Task<CompositePrimaryKey> Create(CompositePrimaryKey item);

		Task Update(CompositePrimaryKey item);

		Task Delete(int id);

		Task<CompositePrimaryKey> Get(int id);

		Task<List<CompositePrimaryKey>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a958ef6d87aac8d8295254d3f9d6113f</Hash>
</Codenesium>*/