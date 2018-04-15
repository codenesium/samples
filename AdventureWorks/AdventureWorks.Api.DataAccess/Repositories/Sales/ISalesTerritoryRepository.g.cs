using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesTerritoryRepository
	{
		int Create(SalesTerritoryModel model);

		void Update(int territoryID,
		            SalesTerritoryModel model);

		void Delete(int territoryID);

		ApiResponse GetById(int territoryID);

		POCOSalesTerritory GetByIdDirect(int territoryID);

		ApiResponse GetWhere(Expression<Func<EFSalesTerritory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSalesTerritory> GetWhereDirect(Expression<Func<EFSalesTerritory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bf55eb24600a8bb237331d14feee1224</Hash>
</Codenesium>*/