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

		Task<List<Clasp>> Clasps(int nextChainId, int limit = int.MaxValue, int offset = 0);

		Task<List<Link>> Links(int chainId, int limit = int.MaxValue, int offset = 0);

		Task<ChainStatu> GetChainStatu(int chainStatusId);

		Task<Team> GetTeam(int teamId);
	}
}

/*<Codenesium>
    <Hash>0b7ed3bcaa7e6d936ba39db45282af5e</Hash>
</Codenesium>*/