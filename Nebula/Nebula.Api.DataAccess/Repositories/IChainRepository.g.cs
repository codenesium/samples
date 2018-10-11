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

		Task<List<Link>> Links(int chainId, int limit = int.MaxValue, int offset = 0);

		Task<ChainStatus> ChainStatusByChainStatusId(int chainStatusId);

		Task<Team> TeamByTeamId(int teamId);

		Task<List<Chain>> ByNextChainId(int nextChainId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>9ad540f113ce6ab88a95aeb6ae7551fb</Hash>
</Codenesium>*/