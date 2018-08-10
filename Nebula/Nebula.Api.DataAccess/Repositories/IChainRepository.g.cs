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

		Task<List<Clasp>> Clasps(int nextChainId, int limit = int.MaxValue, int offset = 0);

		Task<List<Link>> Links(int chainId, int limit = int.MaxValue, int offset = 0);

		Task<ChainStatus> GetChainStatus(int chainStatusId);

		Task<Team> GetTeam(int teamId);
	}
}

/*<Codenesium>
    <Hash>6bf7d313c30556e021e2c0645d76b6f0</Hash>
</Codenesium>*/