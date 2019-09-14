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

		Task<List<ChainStatus>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ChainStatus> ByName(string name);

		Task<List<Chain>> ChainsByChainStatusId(int chainStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3ebe21d01908051d4d1383b67f6dd0c6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/