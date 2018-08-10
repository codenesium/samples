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

		Task<Chain> GetChain(int nextChainId);
	}
}

/*<Codenesium>
    <Hash>edefdcca9f871e6f5e11a5688fa6e20e</Hash>
</Codenesium>*/