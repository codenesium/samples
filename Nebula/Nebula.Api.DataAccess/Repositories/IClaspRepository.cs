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

		Task<List<Clasp>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Chain> ChainByNextChainId(int nextChainId);

		Task<Chain> ChainByPreviousChainId(int previousChainId);
	}
}

/*<Codenesium>
    <Hash>2a75a0987d7700629eaf5f852d44a7ad</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/