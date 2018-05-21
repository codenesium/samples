using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesTerritoryHistoryRepository
	{
		Task<POCOSalesTerritoryHistory> Create(ApiSalesTerritoryHistoryModel model);

		Task Update(int businessEntityID,
		            ApiSalesTerritoryHistoryModel model);

		Task Delete(int businessEntityID);

		Task<POCOSalesTerritoryHistory> Get(int businessEntityID);

		Task<List<POCOSalesTerritoryHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4cb15fbbada741aebc68b12a7eee8d5a</Hash>
</Codenesium>*/