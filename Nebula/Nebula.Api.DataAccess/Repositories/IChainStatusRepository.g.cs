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

		Task<List<ChainStatus>> ByTeamId(int teamId, int limit = int.MaxValue, int offset = 0);

		Task<Chain> CreateChain(Chain item);

		Task DeleteChain(Chain item);
	}
}

/*<Codenesium>
    <Hash>43ededd03f8c07c14da58211d4a130cb</Hash>
</Codenesium>*/