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
    <Hash>1fe7e6c67f913b58d9aa0cf80454b9e3</Hash>
</Codenesium>*/