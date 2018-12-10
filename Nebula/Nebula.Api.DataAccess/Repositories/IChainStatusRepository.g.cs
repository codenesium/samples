using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public partial interface IChainStatusRepository
	{
		Task<ChainStatus> Create(ChainStatus item);

		Task Update(ChainStatus item);

		Task Delete(int id);

		Task<ChainStatus> Get(int id);

		Task<List<ChainStatus>> All(int limit = int.MaxValue, int offset = 0);

		Task<ChainStatus> ByName(string name);

		Task<List<Chain>> ChainsByChainStatusId(int chainStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>da6fe4271d124d2728f8055b6c7b9703</Hash>
</Codenesium>*/