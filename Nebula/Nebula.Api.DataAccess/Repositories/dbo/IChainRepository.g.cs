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

		Task<POCOChain> ExternalId(Guid externalId);
	}
}

/*<Codenesium>
    <Hash>439aabe8db2c776b6b0aa965c79045dc</Hash>
</Codenesium>*/