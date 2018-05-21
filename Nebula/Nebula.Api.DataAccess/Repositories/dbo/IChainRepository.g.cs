using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IChainRepository
	{
		Task<POCOChain> Create(ApiChainModel model);

		Task Update(int id,
		            ApiChainModel model);

		Task Delete(int id);

		Task<POCOChain> Get(int id);

		Task<List<POCOChain>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOChain> GetExternalId(Guid externalId);
	}
}

/*<Codenesium>
    <Hash>6a4d5559e4e7042aa1855d0cb248ef82</Hash>
</Codenesium>*/