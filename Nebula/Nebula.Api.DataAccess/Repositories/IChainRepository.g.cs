using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public partial interface IChainRepository
	{
		Task<Chain> Create(Chain item);

		Task Update(Chain item);

		Task Delete(int id);

		Task<Chain> Get(int id);

		Task<List<Chain>> All(int limit = int.MaxValue, int offset = 0);

		Task<Chain> ByExternalId(Guid externalId);

		Task<List<Link>> LinksByChainId(int chainId, int limit = int.MaxValue, int offset = 0);

		Task<ChainStatus> ChainStatusByChainStatusId(int chainStatusId);

		Task<Team> TeamByTeamId(int teamId);

		Task<List<Chain>> ByPreviousChainId(int previousChainId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d89763db35fbe836781fe5dae1401782</Hash>
</Codenesium>*/