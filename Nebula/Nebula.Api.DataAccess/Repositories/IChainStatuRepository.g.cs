using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public partial interface IChainStatuRepository
	{
		Task<ChainStatu> Create(ChainStatu item);

		Task Update(ChainStatu item);

		Task Delete(int id);

		Task<ChainStatu> Get(int id);

		Task<List<ChainStatu>> All(int limit = int.MaxValue, int offset = 0);

		Task<ChainStatu> ByName(string name);

		Task<List<Chain>> Chains(int chainStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>64f7f7c9890221d0c8566dcb704f6cd4</Hash>
</Codenesium>*/