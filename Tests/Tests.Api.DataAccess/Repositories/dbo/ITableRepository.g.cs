using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public partial interface ITableRepository
	{
		Task<Table> Create(Table item);

		Task Update(Table item);

		Task Delete(int id);

		Task<Table> Get(int id);

		Task<List<Table>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e6b90f91b8abb06956570f430c369252</Hash>
</Codenesium>*/