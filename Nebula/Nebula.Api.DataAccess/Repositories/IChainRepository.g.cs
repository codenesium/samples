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

		Task<List<Clasp>> ClaspsByNextChainId(int nextChainId, int limit = int.MaxValue, int offset = 0);

		Task<List<Clasp>> ClaspsByPreviousChainId(int previousChainId, int limit = int.MaxValue, int offset = 0);

		Task<List<Link>> LinksByChainId(int chainId, int limit = int.MaxValue, int offset = 0);

		Task<ChainStatus> ChainStatusByChainStatusId(int chainStatusId);

		Task<Team> TeamByTeamId(int teamId);
	}
}

/*<Codenesium>
    <Hash>081523efec8e790342adffe530dea509</Hash>
</Codenesium>*/