using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public interface IChainRepository
	{
		Task<Chain> Create(Chain item);

		Task Update(Chain item);

		Task Delete(int id);

		Task<Chain> Get(int id);

		Task<List<Chain>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>36c4252638c075d76639667ab06cd3cd</Hash>
</Codenesium>*/