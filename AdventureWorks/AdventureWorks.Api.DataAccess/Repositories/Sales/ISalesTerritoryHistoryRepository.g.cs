using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesTerritoryHistoryRepository
	{
		POCOSalesTerritoryHistory Create(ApiSalesTerritoryHistoryModel model);

		void Update(int businessEntityID,
		            ApiSalesTerritoryHistoryModel model);

		void Delete(int businessEntityID);

		POCOSalesTerritoryHistory Get(int businessEntityID);

		List<POCOSalesTerritoryHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>94d471c0a6d6180c9d96cdb5c72a10cf</Hash>
</Codenesium>*/