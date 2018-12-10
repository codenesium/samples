using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public partial interface IClaspRepository
	{
		Task<Clasp> Create(Clasp item);

		Task Update(Clasp item);

		Task Delete(int id);

		Task<Clasp> Get(int id);

		Task<List<Clasp>> All(int limit = int.MaxValue, int offset = 0);

		Task<Chain> ChainByNextChainId(int nextChainId);

		Task<Chain> ChainByPreviousChainId(int previousChainId);
	}
}

/*<Codenesium>
    <Hash>e15dd19430ba0bec65a88fb3bcd487ee</Hash>
</Codenesium>*/