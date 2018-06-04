using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesTerritoryHistoryRepository
	{
		Task<SalesTerritoryHistory> Create(SalesTerritoryHistory item);

		Task Update(SalesTerritoryHistory item);

		Task Delete(int businessEntityID);

		Task<SalesTerritoryHistory> Get(int businessEntityID);

		Task<List<SalesTerritoryHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1a4aec7fa3a2e30f4ce3b1ceeb1afdb9</Hash>
</Codenesium>*/