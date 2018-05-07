using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesTerritoryHistoryRepository
	{
		int Create(SalesTerritoryHistoryModel model);

		void Update(int businessEntityID,
		            SalesTerritoryHistoryModel model);

		void Delete(int businessEntityID);

		POCOSalesTerritoryHistory Get(int businessEntityID);

		List<POCOSalesTerritoryHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2971c591bee0c674211e60ede3c50da9</Hash>
</Codenesium>*/